    //declare a dictionary pre initialized with all the properties we will ask for
    var d = new Dictionary<string, int> {
      ["Age"] = 0, ["weight"] = 0, ["height"] = 0, ["width"] = 0
    };
 
    //for each of the keys (toarray makes a new collection so we are not enumerating the collection we are modifying)
    foreach(var key in d.Keys.ToArray()){
      //uses string interpolation to compose a string using the key name (age, height etc)
      Console.WriteLine($"enter {key}:");
	  int val = 0; //to store the value we parse
      //while the user enters bad input and we can't parse it
      while(!int.TryParse(Console.ReadLine(), out val)){
        Console.WriteLine($"need an integer input for {key}:" );
      }
      //store the parsed value in the dictionary against the current key
      d[key] = val;
    }
    //example of use
    Console.WriteLine($"Your BMI is {10000.0 * d["weight"] / d["height"] / d["height"]}");
    
    
