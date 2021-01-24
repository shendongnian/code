    var items = new Dictionary<(int, int), string>();
    
    items.Add((0,1), "0-1"); //this throws an error if the key already exists
    items[(2,3)] = "2-3";    //this silently replaces the value if the key already exists
    
    Console.WriteLine(items.Keys.Contains((0,1))); //true
    Console.WriteLine(items.Keys.Contains((0,2))); //false
    
    Console.WriteLine(items[(2,3)]); //"2-3"
