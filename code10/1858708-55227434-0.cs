csharp
using sodacrate;
using System;
namespace sodacrate
{
    class Sodacrate
    {
        private string[] flaskor = new string[24];
        private int antal_flaskor = 0;
        public int sum = 0;
        public void Run()
        {
            Console.WriteLine("|*|Välkommen till läskbacken!|*|");
            int temp = 0;
            do
            {
                Console.WriteLine("|*|Välj ett alternativ|*|");
                Console.WriteLine("/~*/~*/~*/~*/~*/~*/~*/~*/~*/~*/~*/~*/~*/~*/");
                Console.WriteLine("(1): Lägg till en läsk");
                Console.WriteLine("(2): Skriv ut innehållet i läskbacken");
                Console.WriteLine("(3): Beräkna totala värdet på läskbacken");
                Console.WriteLine("(4): Avsluta programmet");
                temp = int.Parse(Console.ReadLine());
                switch (temp)
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
                        Console.WriteLine("Programmet avslutas...");
                        break;
                    default:
                        Console.WriteLine("Ogiltig inmatning");
                        break;
                }
            } while (temp != 0);
        }
        public void add_soda()
        {
            if (antal_flaskor == 24)
            {
                Console.WriteLine("Läskbacken är full, du kan inte lägga till fler flaskor!");
                return;
            }
            Console.WriteLine("    |*|*|~MENY~|*|*|");
            Console.WriteLine("    Välj valfri läsk");
            Console.WriteLine("/------------------/");
            Console.WriteLine("(1): Coca-Cola   5kr");
            Console.WriteLine("(2): Fanta       5kr");
            Console.WriteLine("(3): Sprite      5kr");
            Console.WriteLine("(4): Pepsi       5kr");
            Console.WriteLine("(5): Trocadero   5kr");
            Console.WriteLine("/------------------/");
            int temp = int.Parse(Console.ReadLine());
            bool meny = true;
            do
            {
                switch (temp)
                {
                    case 1:
                        Console.WriteLine("Coca-Cola");
                        meny = false;
                        break;
                    case 2:
                        Console.WriteLine("Fanta");
                        meny = false;
                        break;
                    case 3:
                        Console.WriteLine("Sprite");
                        meny = false;
                        break;
                    case 4:
                        Console.WriteLine("Pepsi");
                        meny = false;
                        break;
                    case 5:
                        Console.WriteLine("Trocadero");
                        meny = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltig inmatning");
                        meny = false;
                        break;
                }
            } while (meny);
            Console.WriteLine("Tryck för att återgå till menyn...");
        }
        public void print_crate()
        {
            foreach (var dryck in flaskor)
            {
                if (dryck != null)
                    Console.WriteLine(dryck);
                else
                    Console.WriteLine("Ledig");
            }
        }
        public int calc_total()
        {
            int total = 0;
            foreach (var dryck in flaskor)
            {
                if (dryck != null)
                    total += 5;
            }
            return total;
        }
    }
}
    
class Program
{
    public static void Main(string[] args)
    {
        var sodacrate = new Sodacrate();
        sodacrate.Run();
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }
}
<br>
Also notice that you need a ```using sodacrate;``` to create a new object of Sodacrate in your Program class!
