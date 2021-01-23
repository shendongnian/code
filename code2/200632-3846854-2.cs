    delegate void Script();
    
    class GameObject
    {
    	public Dictionary<string, Script> Scripts {get; set;}
    	public string Name {get; set;}
    	
    	//etc...
    }
