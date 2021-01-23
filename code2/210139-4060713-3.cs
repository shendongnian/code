    public void Log(string message)
    {
        using(StreamWriter sw = new StreamWriter(File.Append(path)))
        {
            sw.WriteLine(message);
        }
    }
    public static void Main()
    {
        Log("Hello");
        Log("World");
    }
