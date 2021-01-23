    static void Main() {
        Program p = new Program();
        var s = p.Ten2SevenAsync();
        Console.WriteLine(s.Result);
    }
