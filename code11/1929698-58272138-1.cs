    //                                           test                   test, test_[2], test_[3]
    protected string GetDistinctName2(string currentName, IEnumerable<string> existingNames)
    {
        int iteration = 0;
        // Use a different variable this will prevent you from adding [0] again and again
        var result = currentName;
        if (existingNames.Where(s => s != currentName).Any(n => n.Equals(result)))
        {
            do
            {
                // Use square brackets
                if (!result .EndsWith($"[{iteration}]"))
                {
                    result = $"{currentName}_[{iteration}]";
                }
                iteration++; // Increment with every step
            }
            while (existingNames.Any(n => n.Equals(result)));
        }
        return result;
    }
