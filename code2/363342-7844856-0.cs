    public static void RefExample(ref int y)
    {
        y = 3;
    }
    
    main()
    {
        int x = 5;
        RefExample(ref x);
        Console.WriteLine(x); // prints 3
    }
