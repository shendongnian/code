    foreach(var subdirectory in Directory.GetDirectories(@"c:\Dir\"))
    //foreach(var subdirectory in Directory.GetDirectories(@"c:\Dir\", "*", SearchOption.AllDirectories))
    {
        // using GetFileName because subdirectory doesnt end with "\"
    	var name = Path.GetFileName(subdirectory);
    	var count = Directory.GetFiles(subdirectory, "*", SearchOption.AllDirectories).Length;
    	Console.WriteLine($"Name: {name} Count: {count}");
    }
