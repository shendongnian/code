    var column1 = new List<string>();
    var column2 = new List<string>();
    using (var rd = new StreamReader("filename.csv"))
    {
        while (!rd.EndOfStream)
        {
            var splits = rd.ReadLine().Split(';');
            column1.Add(splits[0]);
            column2.Add(splits[1]);
        }
    }
    // print column1
    Console.WriteLine("Column 1:");
    foreach (var element in column1)
        Console.WriteLine(element);
    
    // print column2
    Console.WriteLine("Column 2:");
    foreach (var element in column2)
        Console.WriteLine(element);
 
