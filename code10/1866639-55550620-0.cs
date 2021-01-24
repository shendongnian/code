    private static int GetCount(string line)
    {
        return (int)Convert.ToDouble(
            line.Split('|')[2]
                .Replace(" ", "")
                .Replace(',', '.'));
    }
