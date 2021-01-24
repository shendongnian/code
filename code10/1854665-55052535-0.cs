    private static void Main(string[] args)
    {
        int slump_tal = new Random().Next(1, 101);
        int tal;
        Console.WriteLine("Minigame: Gissa talet!\n");
        Console.WriteLine("Skriv in ett tal mellan 1 och 100:");
        do
        {
            tal = Convert.ToInt32(Console.ReadLine());
            if (tal < slump_tal)
            {
                Console.WriteLine("Fel! Större!");
            }
            else if (tal > slump_tal)
            {
                Console.WriteLine("Fel! Mindre!");
            }
        } while (tal != slump_tal);
        Console.WriteLine("Grattis! Du gissade rätt!");
        Console.WriteLine("Tryck på en tangent för att avsluta...");
        Console.ReadLine();
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
