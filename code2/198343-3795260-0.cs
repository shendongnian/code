    public static void OutputEnumValues(Enum example)
    {
        foreach (string name in Enum.GetNames(example.GetType()))
        {
            Console.WriteLine(name);
        }
    }
