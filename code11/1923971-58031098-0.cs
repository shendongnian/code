    class Player
    {
    	public Player(string Name, int Age) : this()
    	{
    		this.Name = Name;
    		this.Age = Age;
    	}
    
    	public string Name { get; set; }
    	
    	public int Age { get; set; }
    	
    	public Dictionary<int, string> Items { get; set; } = new Dictionary<int, string>();
    
    	public float Health { get; set; } = 20;
    	
    	public float Damage { get; set; }
    
    	public void AddItems(int key, string item)
    	{
    		this.Items.Add(key, item);
    	}
    
    }
