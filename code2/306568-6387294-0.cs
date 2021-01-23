    static void Main(string[] args)
    {
        foreach (string exename in System.IO.File.ReadAllLines("test.txt"))
        {
            Process.Start("test.exe", "\"" + exename + "\"").WaitForExit();
        }
    
    }
