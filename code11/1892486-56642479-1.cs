    private static int potionType = 0;
    private static List<BasePotion> potions;
    static void Main(string[] args)
    {
                
        Console.WriteLine("Started.....");
        potions = new List<BasePotion>();
        for (int i = 0; i <= 5; i++)
        {
            var newPortion = CreatePotion();
            potions.Add(newPortion);
            Console.WriteLine(newPortion.ToString());
        }
    
        Console.WriteLine("Completed.....");
        Console.ReadLine();
    }
