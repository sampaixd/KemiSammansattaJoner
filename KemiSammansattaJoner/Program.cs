using System;

namespace KemiSammansattaJoner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namn = new string[21];
            string[] förkortning = new string[21];
            bool[] gjord = new bool[21];
            namn[0] = "ammoniumjon";
            namn[1] = "ammoniak";
            namn[2] = "sulfatjon";
            namn[3] = "vätesulfatjon";
            namn[4] = "svavelsyra";
            namn[5] = "cyanidjon";
            namn[6] = "fosfatjon";
            namn[7] = "vätefosfatjon";
            namn[8] = "divätefosfatjon";
            namn[9] = "fosforsyra";
            namn[10] = "sulfitjon";
            namn[11] = "karbonatjon";
            namn[12] = "vätekarbonatjon";
            namn[13] = "kolsyra";
            namn[14] = "salpetersyra";
            namn[15] = "nitratjon";
            namn[16] = "nitritjon";
            namn[17] = "permanganatjon";
            namn[18] = "hydroxidjon";
            namn[19] = "oxoniumjon";
            namn[20] = "tiocyanatjon";
            förkortning[0] = "NH4^1+";
            förkortning[1] = "NH3";
            förkortning[2] = "SO4^2-";
            förkortning[3] = "HSO4^1-";
            förkortning[4] = "H2SO4";
            förkortning[5] = "CN^-";
            förkortning[6] = "PO4^3-";
            förkortning[7] = "HPO4^2-";
            förkortning[8] = "H2PO4^1-";
            förkortning[9] = "H3PO4";
            förkortning[10] = "SO3^2-";
            förkortning[11] = "CO3^2-";
            förkortning[12] = "HCO3^1-";
            förkortning[13] = "H2CO3";
            förkortning[14] = "HNO3";
            förkortning[15] = "NO3^1-";
            förkortning[16] = "NO2^1-";
            förkortning[17] = "MnO4^1-";
            förkortning[18] = "OH^1-";
            förkortning[19] = "H3O^1+";
            förkortning[20] = "SCN^1-";


            string input;
            bool program = true;
            Random rng = new Random();
            int val1 = 0;   //används för att bestämma vad du väljer för inställningar
            int val2 = 0;
            int slutval = 0;    //val om vad som ska hända efter man är klar
            bool nyainställningar = true;

            Console.WriteLine("Välkommen till sampas program för att öva på sammansatta joner!");
            Console.WriteLine("Tryck på valfri knapp för att börja öva på de sammansatta jonerna man ska kunna inför kemiprovet på fredag");
            Console.ReadKey();
            Console.Clear();


            while (program)
            {
                int poäng = 0;
                if (nyainställningar == true)
                {
                    val1 = Valmeny("Vad vill du bli förhörd på?", "namnen ", "förkortningarna ", "blandat ");
                    val2 = Valmeny("Vilken ordning ska förhöret gå?", "först>sist ", "sist>först ", "blandat ");
                }
                switch (val2)
                {
                    case 0:
                        poäng = Förstsist(val1, namn, förkortning, rng);
                        break;
                    case 1:
                        poäng = Sistförst(val1, namn, förkortning, rng);
                        break;
                    case 2:
                        poäng = Slumpat(val1, namn, förkortning, rng, gjord);
                        break;
                }
                Console.WriteLine("Poäng: " + poäng + " utav 21");
                Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                Console.ReadKey();
                slutval = Valmeny("Vad vill du göra nu?", "Förhör igen med nya inställningar ", "Förhör igen med samma inställningar ", "avsluta programmet ");
                switch (slutval)
                {
                    case 0:
                        nyainställningar = true;
                        break;
                    case 1:
                        nyainställningar = false;
                        break;
                    case 2:
                        program = false;
                        break;
                }

            }
        }
        public static int Valmeny(string fråga, string val1, string val2, string val3)    //funktion som låter dig bestämma inställningar inför förhöret
        {
            bool loop = true;
            int val = 0;
            int menyarrow = 0;
            while (loop)
            {
                Console.WriteLine(fråga);
                if (menyarrow == 0)
                { Console.WriteLine(val1 + "<"); }
                else
                { Console.WriteLine(val1); }
                if (menyarrow == 1)
                { Console.WriteLine(val2 + "<"); }
                else
                { Console.WriteLine(val2); }
                if (menyarrow == 2)
                { Console.WriteLine(val3 + "<"); }
                else
                { Console.WriteLine(val3); }
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (menyarrow == 0)
                        { menyarrow = 2; }
                        else
                        { menyarrow--; }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (menyarrow == 2)
                        { menyarrow = 0; }
                        else
                        { menyarrow++; }
                        break;
                    case ConsoleKey.Enter:
                        val = menyarrow;
                        loop = false;
                        break;

                }
                Console.Clear();
            }
            return val;
        }

        public static int Förstsist(int val1, string[] namn, string[] förkortningar, Random rng)
        {
            int poäng = 0;
            for (int i = 0; i < 21; i++)
            {
                poäng = Förhör(val1, namn, förkortningar, rng, poäng, i);
            }
            return poäng;
        }

        public static int Sistförst(int val1, string[] namn, string[] förkortningar, Random rng)
        {
            int poäng = 0;
            for (int i = 20; i > -1; i--)
            {
                poäng = Förhör(val1, namn, förkortningar, rng, poäng, i);
            }
            return poäng;
        }

        public static int Slumpat(int val1, string[] namn, string[] förkortningar, Random rng, bool[] gjord)
        {
            int poäng = 0;
            int slumpadfråga = 0;
            for (int i = 0; i < 21; i++)
            {
                while (true)
                {
                    slumpadfråga = rng.Next(21);
                    if (gjord[slumpadfråga] == false)
                    {
                        poäng = Förhör(val1, namn, förkortningar, rng, poäng, slumpadfråga);
                        gjord[slumpadfråga] = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < 21; i++)
            {
                gjord[i] = false;
            }
            return poäng;
        }
        public static int Förhör(int val1, string[] namn, string[] förkortningar, Random rng, int poäng, int i)
        {
            string fråga1 = "Skriv förkortningen för ";
            string fråga2 = "Skriv namnet för ";
            string input;
            bool random = false;
            if (val1 == 2)
            { random = true; }
            if (random == true)
            { val1 = rng.Next(2); }
            if (val1 == 0)
            {
                Console.WriteLine(fråga1 + namn[i]);
                Console.Write("Ditt svar: ");
                input = Console.ReadLine();
                Console.Clear();
                if (input == förkortningar[i])
                { Console.WriteLine("Korrekt!"); poäng++; }
                else
                { Console.WriteLine("Fel!"); }
                Console.WriteLine("Ditt svar: " + input);
                Console.WriteLine("Rätt svar: " + förkortningar[i]);
            }
            else if (val1 == 1)
            {
                Console.WriteLine(fråga2 + förkortningar[i]);
                Console.Write("Ditt svar: ");
                input = Console.ReadLine();
                Console.Clear();
                if (input == namn[i])
                { Console.WriteLine("Korrekt!"); poäng++; }
                else
                { Console.WriteLine("Fel!"); }
                Console.WriteLine("Ditt svar: " + input);
                Console.WriteLine("Rätt svar: " + namn[i]);
            }
            Console.WriteLine("Tryck på valfri knapp för att fortsätta");
            Console.ReadKey();
            Console.Clear();
            return poäng;
        }
    }
}
