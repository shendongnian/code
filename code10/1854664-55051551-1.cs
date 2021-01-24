    namespace Uppgift_1___Gissa_talet
    {
        class Program
        {
            static void Main(string[] args)
            {
            Random randomerare = new Random();
            int slump_tal = randomerare.Next(1, 101);
            Console.WriteLine("Minigame: Gissa talet!");
            Console.WriteLine();
            Console.WriteLine("Skriv in ett tal mellan 1 och 100:");
            string str = Console.ReadLine();
            int tal = Convert.ToInt32(str);
            do //You start the loop before the test expression is checked
            {
                if (tal < slump_tal) //Är det mindre?
                {
                    Console.WriteLine("Fel! Större!");//Säg då att det ska vara större
                }
                else if (tal > slump_tal)
                {
                    Console.WriteLine("Fel! Mindre!");
                }
                tal = Convert.ToInt32(Console.ReadLine());//Läs in nästa gissning
            }while(tal != slump_tal); // The test expression is checked here.
            Console.WriteLine("Grattis! Du gissade rätt!");
            Console.WriteLine("Tryck på en tangent för att avsluta...");
            Console.ReadLine();
            }
           }
    }
