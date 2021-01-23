    public bool IsInTheRange(int parameter)
    {
        string range = "0A-OF";
        int min = int.Parse(range.Split('-')[0], System.Globalization.NumberStyles.HexNumber);
        int max = int.Parse(range.Split('-')[1], System.Globalization.NumberStyles.HexNumber);
        return parameter >= min && parameter <= max;
    }
