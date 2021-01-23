    var types = new HashSet<Type>();
    types.Add(typeof(int)); //Fill it with types
    types.Add(typeof(double));
    //Check by getting types from their string name, you could of course also cache those types
    Console.WriteLine("Contains int: " + types.Contains(Type.GetType(intName))); //True
    Console.WriteLine("Contains float: " + types.Contains(Type.GetType(floatName))); //False
