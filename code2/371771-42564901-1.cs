    static void Main(string[] args)
    {
        var list = new List<string>();
        for (int i = 0; i < 5 * 1000 * 1000; i++)
        {
            var s = ReadFromDb();
            list.Add(string.Intern(s));
            //list.Add(s);
        }
        Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024 + " MB");
    }
    private static string ReadFromDb()
    {
        return "abcdefghijklmnopqrstuvyxz0123456789abcdefghijklmnopqrstuvyxz0123456789abcdefghijklmnopqrstuvyxz0123456789" + 1;
    }
