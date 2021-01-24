    static async Task Main(string[] args)
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("coffee is ready");
        Egg eggs = await FryEggs(2);
        Console.WriteLine("eggs are ready");
        Bacon bacon = await FryBacon(3);
        Console.WriteLine("bacon is ready");
        Toast toast = await ToastBread(2);
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("toast is ready");
        Juice oj = PourOJ();
        Console.WriteLine("oj is ready");
    
        Console.WriteLine("Breakfast is ready!");
    }
