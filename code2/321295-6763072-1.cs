    var blah = "";
    
    var split = blah.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);
    var split2 = blah.Split(new[]{';'});
    
    // Returns zero
    Console.WriteLine(split.Length);
    
    // Returns one
    Console.WriteLine(split2.Length);
