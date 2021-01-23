    string splitter = ", ";
    string newLine = "<br/>";
    int splitAfter = 3;
    string s = "tom: 1, john: 3, timmy: 5, cid: 8, ad: 88, hid: 99, mn: 33";
    string x = 
       s.Split(new[]{splitter}, StringSplitOptions.None) // Split
        // Make each string entry into a Tuple containing the string itself 
        // and an integer key declaring into which group it falls
        .Select((v, i) => 
           new Tuple<int, string>((int) Math.Floor((double) i/splitAfter), v)) 
        // Group by the key created in the line above
        .GroupBy(kvp => kvp.Item1)
        // Since the key is not needed any more select only the string value
        .Select(g => g.Select(kvp => kvp.Item2) 
        // Join the groups 
        // (in your example each group is a collection of 3 elements)
        .Aggregate((a, b) => a + splitter + b)) 
        // Join all the groups and add a new line in between
        .Aggregate((a, b) => a + splitter + newLine + b); 
