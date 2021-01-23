    var parsed = File.ReadLines("SO.txt")
                     .Select(line => line.Split(' ') 
                                         .Select(MyIntegerParse)  // pick out each item as an int
                                         .ToArray())  // get array of ints 
                     .ToArray();  // return as int[][]
    ....
    
    static int MyIntegerParse(string possibleInt)
    {
         int i;
         return int.TryParse(possibleInt, out i) ? i : 0;
    }
    
