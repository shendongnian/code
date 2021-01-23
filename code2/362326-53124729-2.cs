    // Define enum TestType without values
    enum TestType{}
    // Define a dictionary for enum values
    Dictionary<int,string> d = new Dictionary<int,string>();
    
    public void NewEnumValue(int i, string v)
    {
        try
        {
            string test = d[i];
            Console.WriteLine("This Key is already assigned with value: " + 
                               test);
        }
        catch
        {
            d.Add(i,v);
            Console.WriteLine("Addition Done!");
        }
    }
    
    void Main()
    {
        int i = 5;
        TestType s = (TestType)i;
        TestType e = (TestType)2;
    
        // Definging enum int values with string values
    
        NewEnumValue(2,"Aphasia");
        NewEnumValue(5,"FocusedAphasia");
        Console.WriteLine("You will add int with their values; type 0 to " +
                          "exit");
        while(true)
        {
            Console.WriteLine("enum int:");
            int ii = Convert.ToInt32(Console.ReadLine());
            if (ii == 0) break;
            Console.WriteLine("enum value:");
            string v = Console.ReadLine();
            Console.WriteLine("will try to assign the enum TestType with " + 
                              "value: " + v + " by '" + ii + "' int value.");
            NewEnumValue(ii,v);
        }
    
        // Results:
        Console.WriteLine(d[(int)s]); // Result: FocusedAphasia
        Console.WriteLine(d[(int)e]); // Result: Aphasia
    }
