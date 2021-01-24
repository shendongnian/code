    // Get lines as list.
    var lines = GetFileLines(@"c:\test.txt").ToList();
    // How many lines are there?
    var numberOfLines = lines.Count;
            
    // Add a new line.
    lines.Add("This is another line we are adding to our list");
    // If you want it as an array, make an array from the list after manipulating
    var lineArray = lines.ToArray();
