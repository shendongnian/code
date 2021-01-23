    // StartNew happens to be a quicker way to create and initialize a Stopwatch
    Stopwatch triptime = Stopwatch.StartNew();
    Console.WriteLine("You have started the trip");
    // you can use collection initializer syntax to make it nicer to read when
    // you want to add lots of things to a data structure
    var tdItems = new Dictionary<string, string> {
        { "1", "foo" },
        { "2", "bar" },
        { "3", "baz" },
        { "4", "end" },
    };
    while (true)
    {
        string[] items = Console.ReadLine().Split(' ');
        // you can use format strings to easily customize the stringification
        // of DateTime and TimeSpan objects, see the MSDN docs
        string time = string.Format("{0:c}", triptime.Elapsed);
        List<string> waypoints = new List<string>();
        // it's easiest to first find the destinations your trip has to visit
        foreach (string itemNumber in items)
        {
            if (tdItems.ContainsKey(itemNumber))
                waypoints.Add(tdItems[itemNumber]);
            else
                Console.WriteLine(
                  "You have entered a drop which is not in the database...");
        }
        // string.Join is an easy way to avoid worrying about putting an extra
        // "+" at the front or end
        string tripDescription = string.Join(" + ", waypoints);
        // "using" is generally important so you don't hold a lock on the file
        // forever, and it saves you from manually calling "flush" -- it
        // flushes when the writers are disposed at the end of the using block
        using (var objWriter = new StreamWriter(@"D:\text1.txt", true))
        using (var tripWriter = new StreamWriter(@"D:\text2.txt", true))
        {
            // WriteLine adds a newline for you
            objWriter.WriteLine(tripDescription);
            tripWriter.WriteLine(tripDescription);
        }
        if (waypoints.Contains("end"))
        {
            Console.WriteLine("End of Trip");
            Console.WriteLine("Elapsed time " + time);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            break;
        }
    }
    // you'll get the welcome menu again when you return from this function
