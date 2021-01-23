    object ConvertToAny(string input)
    {
        int i;
        if (int.TryParse(input, out i))
            return i;
        double d;
        if (double.TryParse(input, out d))
            return d;
        return input;
    }
