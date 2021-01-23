    var parsed = File.ReadLines("SO.txt")
                     .Select(line => line.Split(' ') 
                                         .Where(IsInteger)
                                         .Select(s => int.Parse(s))  // pick out each item as an int
                                         .ToArray())  // get array of ints 
                     .ToArray();  // return as int[][]
    ....
    
    static bool IsInteger(string possibleInt)
    {
         int i;
         return int.TryParse(possibleInt, out i);
    }
    
