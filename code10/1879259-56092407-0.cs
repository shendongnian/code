    using System;
    namespace sodacrate
    {
    public class Flaska
    {
        private string namn;
        private int pris;
        public Flaska(string _namn, int _pris)
        {
            namn = _namn;
            pris = _pris;
        }
        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }
        public int Pris
        {
            get { return pris; }
            set { pris = value; }
        }
    }
    class Sodacrate
    {
        private Flaska[] flaskor;
        private int antal_flaskor = 0; //Håller reda på antal flaskor
        public Sodacrate()
        {
            flaskor = new Flaska[24];
        }
        public void Run()
        {
            Console.WriteLine("Välkommen till detta läskbacksprogramm."); //Text som välkommnar användaren
            int input = 0;
            do
            {
                Console.WriteLine("Välj ett alternativ som du vill ska utföras:");
                Console.WriteLine("1. Lägg till flaskor till läskbacken");
                Console.WriteLine("2. Se vilka flaskor som finns i läskbacken");
                Console.WriteLine("3. Räkna ut totalpriset för läskbacken");
                Console.WriteLine("4. Stäng av program");
                input = int.Parse(Console.ReadLine()); //Tar emot input och omvandlar till en integer
                switch (input)
                {
                    case 1:
                        add_soda();
                        break;
                    case 2:
                        print_crate();
                        break;
                    case 3:
                        calc_total();
                        break;
                    case 4:
                        Console.WriteLine("Programmet avslutas");
                        break;
                    default:
                        Console.WriteLine("Fel inmatning. Var vänlig och välj bland alternativ ovanför.");
                        break;
                }
            } while (input != 0);
        }
        public void add_soda()
        {
            Console.WriteLine("Välj dryck att lägga till i läskbacken:");
            Console.WriteLine("1. Fanta, 10 kr");
            Console.WriteLine("2. Coca-Cola, 15 kr");
            Console.WriteLine("3. Sprite, 9 kr");
            Console.WriteLine("4. Mountain Dew, 17 kr");
            int input = 0; //Skapa variabel för att ta emot input
            for (int i = 0; i < flaskor.Length; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out input) || !(input <= 4 && input >= 1))  //Ser till att man bara kan skriva in vad programmet frågar efter.
                {
                    Console.WriteLine("Fel inmatning. Var vänlig och välj bland alternativ ovanför.");
                }
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Du valde Fanta.");
                        flaskor[antal_flaskor] = new Flaska("Fanta", 10);
                        antal_flaskor++;
                        break;
                    case 2:
                        Console.WriteLine("Du valde Coca-Cola.");
                        flaskor[antal_flaskor] = new Flaska("Coca-Cola", 15);
                        antal_flaskor++;
                        break;
                    case 3:
                        Console.WriteLine("Du valde Sprite.");
                        flaskor[antal_flaskor] = new Flaska("Sprite", 9);
                        antal_flaskor++;
                        break;
                    case 4:
                        Console.WriteLine("Du valde Mountain Dew.");
                        flaskor[antal_flaskor] = new Flaska("Mountain Dew", 17);
                        antal_flaskor++;
                        break;
                    default:
                        Console.WriteLine("Fel inmatning. Var vänlig och välj bland alternativ ovanför.");
                        break;
                }
            }
        }
        public void print_crate()
        {
            for (int i = 0; i < flaskor.Length; i++)
            {
                if (flaskor[i] != null)
                {
                    Console.WriteLine("Index: {0}. Namn: {1}, Pris: {2}", i, flaskor[i].Namn, flaskor[i].Pris);
                }
                else
                {
                    Console.WriteLine("Tom plats.");
                }
            }
        }
        public int calc_total()
        {
            int summa = 0;
            for (int i = 0; i < antal_flaskor; i++)
            {
                summa += flaskor[i].Pris;
            }
            Console.WriteLine($"Det totala priset blir {summa} kr.");
            return summa;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Sodacrate som heter sodacrate
            Sodacrate Läskback = new Sodacrate();
            var sodacrate = new Sodacrate();
            sodacrate.Run();
            Läskback.print_crate();
            Läskback.calc_total();
            Läskback.add_soda();
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }
    }
