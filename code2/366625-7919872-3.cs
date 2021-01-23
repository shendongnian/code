    object StringToDoubleIfPossible(string s)
    {
        double parseResult;
        return !string.IsNullOrEmpty(s) && double.TryParse(s, out parseResult) ? (object)parseResult : s;
    }
