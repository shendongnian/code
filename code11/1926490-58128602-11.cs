    public void AskAll(){
        foreach(var key in _d.Keys.ToArray()){
          _d[key] = AskFor(key);
        }
    }
    public int AskFor(string what)
    {
        Console.WriteLine($"enter {what}:");
        int val = 0; 
        while(!int.TryParse(Console.ReadLine(), out val)){
            Console.WriteLine($"need an integer input for {what}:" );
        }
        return val;
    }
    
