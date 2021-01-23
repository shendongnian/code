    public string TrySumTwoStrings(string input1, string input2)
    {
        double numeric1, numeric2;
        if (Double.TryParse(input1, out numeric1) && Double.TryParse(input2, out numeric2))
            return (numeric1 + numeric2).ToString();
        return input1 + input2;
    }
