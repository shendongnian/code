        Test t = Test.a | Test.c;
        string s = t.ToString();
        Console.WriteLine(s);
        Test u = ParseNames<Test>(s);
        Console.WriteLine(u);
