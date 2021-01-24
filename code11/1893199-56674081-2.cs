    private static Random _rnd = new Random();
    static void Main()
    {
        List<WeightUnit> weights = new List<WeightUnit>
        {
            new WeightUnit("1", 20),
            new WeightUnit("2", 20),
            new WeightUnit("3", 20),
            new WeightUnit("4", 10),
            new WeightUnit("5", 10),
            new WeightUnit("6", 10)
        };
        Dictionary<string, int> result = new Dictionary<string, int>();
        WeightUnit selected = null;
        for (int i = 0; i < 1000; i++)
        {
            selected = GetRandom(weights);
            if (selected != null)
            {
                if (result.ContainsKey(selected.Name))
                {
                    result[selected.Name] = result[selected.Name] + 1;
                }
                else
                {
                    result.Add(selected.Name, 1);
                }
            }
        }
        Console.WriteLine("1\t\t" + result["1"]);
        Console.WriteLine("2\t\t" + result["2"]);
        Console.WriteLine("3\t\t" + result["3"]);
        Console.WriteLine("4\t\t" + result["4"]);
        Console.WriteLine("5\t\t" + result["5"]);
        Console.WriteLine("6\t\t" + result["6"]);
        Console.ReadLine();
    }
