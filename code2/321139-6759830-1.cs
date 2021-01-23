    static void Main () {
        foo();
        bar();
    }
    static void foo () {
        var f = new StreamWriter ("hello.txt");
        f.Write ("hello world");
    }
    static void bar () {
        var f = new StreamReader ("hello.txt");
        Console.WriteLine (f.ReadToEnd ());
    }
