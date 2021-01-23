    var dict = new Dictionary<int, myObject> ();
    dict.Add(2, new myObject(1, "Test1", "Somewhere"));
    dict.Add (1, new myObject (2, "Test2", "location"));
    
    var result = dict.Select (kp => new MyObject2 (kp.Value.Id, kp.Value.Name, kp.Value.Location, kp.Key)).ToList ();
    
     foreach( var r in result )
     {
         Console.WriteLine (r.ToString ());
     }
    
     Console.ReadLine ();
