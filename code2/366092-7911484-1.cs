    string str = "foo\bar\abc.txt";
    string str2 = "bar/foo/foobar";
    
    
    string[] items = str.split(new char[] {'/', '\'}, StringSplitOptions.RemoveEmptyEntries);
    
    Console.WriteLine(items[0]); // prints "foo"
    
    items = str2.split(new char[] {'/', '\'}, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine(items[0]); // prints "bar"
