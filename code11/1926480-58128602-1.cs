    //declare a dictionary pre initialized with all the properties we will ask for
    var d = new Dictionary<string, int> {
      "Age" = 0, "weight" = 0, "height" = 0, "width" = 0
    }
    
    foreach(var key in d.Keys){
      Console.WriteLine($"enter {key}:");
      while(!int.TryParse(Console.ReadLine(), out int val)){
        Console.WriteLine($"need an integer input for {key}:" );
      }
      d[key] = val;
    }
