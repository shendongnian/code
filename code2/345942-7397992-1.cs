    static void Main(string[] args)
    {
        test("A'1", "B**", "'C'D");
    }
    static void test(string a, string b, string c)
    {
        string[] args = new string[] { a, b, c }; //build array
        args = args.Select((s) => s.Replace("'", " ")).ToArray(); //clean array
        a = args[0]; //assign values from array
        b = args[1];
        c = args[2];
    }
