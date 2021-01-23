    public void WriteToConsole(params object[] values)
    {
        string separator = "";
        foreach (object value in values)
        {
            Console.Write(separator);
            separator = " ";
            Console.Write(value);
        }
    }
