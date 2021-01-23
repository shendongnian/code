    static void Main() {
        Program p = new Program();
        var s = p.Ten2SevenAsync();
        s.Wait();
        Console.WriteLine(s.Result);
    }
