    private static bool LinesHaveCorrectLength(string[] lines, int expectedLineLength)
    {
        foreach (string item in lines)
        {
            if (item.Length != expectedLineLength)
            {
                return false;
            }
        }
        return true;
    }
