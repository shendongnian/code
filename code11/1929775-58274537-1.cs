    private static void Main(string[] args)
    {
        ItemMenu steak = GetSteakMenu();
        var modArray = steak.Modifiers.ToArray();
        var combinations = steak.Modifiers.Select(mo => mo.Options).CartesianProduct();
    
        Console.WriteLine($"Total of {combinations.Count()}");
        foreach (var variation in combinations)
        {
            var array = variation.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Modifier: {modArray[i].Name}, Option: {array[i]}");
            }
        }
    
        Console.WriteLine("Done!");
        Console.ReadKey();
    }
