    private static void TestDynamic(dynamic list)
    {
        foreach (var item in list)
        {
            if (item is string)
            {
                string foo = item;//use it as string
                Console.WriteLine("The string is: {0}", foo);
            }
            else
            {
                Console.WriteLine(item);
            }
        }
    }
    
    static void Mian()
    {
        //pass a list of strings
        TestDynamic(new List<string> { "Foo", "Bar", "Baz" });
    
        //pass a list of anonymous class
        TestDynamic(new List<dynamic> { new { Age = 25, BirthDay = new DateTime(1986, 1, 3) }, new { Age = 0, BirthDay = DateTime.Now } });
    
        //TestDynamic(25);//this will cause exception at run time at the foreach line
    }
    
    
    //output:
    The string is: Foo
    The string is: Bar
    The string is: Baz
    { Age = 25, BirthDay = 3/1/1986 00:00:00 }
    { Age = 0, BirthDay = 23/6/2011 01:23:18 }
