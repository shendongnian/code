    public static void generateIdentifiers(int quantity)
    {
        HashSet<int> uniqueIdentifiers = new HashSet<int>();
        while (uniqueIdentifiers.Count < quantity)
        {
            int value = random.Next(111111111, 999999999);
            if (!value.ToString().Contains('0') && !uniqueIdentifiers.Contains(value))
                uniqueIdentifiers.Add(value);
        }
    }
