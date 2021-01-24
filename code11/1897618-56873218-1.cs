        int a = 0;
        ref int b = ref a;
        int c = 1, d = 2;
        b = ref c;
        b = 42;
        System.Console.WriteLine(c); // 42
        System.Console.WriteLine(d); // 2
        b = d;
        b = 64;
        System.Console.WriteLine(c); // 64
        System.Console.WriteLine(d); // 2
