    public override string ToString()
    {
        return string.Format("TANK: Cap: {0} LEVEL: {1}", tankCapacity, tankLevel);
    }
    
    public void display()
    {
       System.Console.WriteLine(GetDisplayString());
    }
	
