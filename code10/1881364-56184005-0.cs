    class Hero : Character
    {
    	int rüstung, gold;
    	
    	public Hero(string name, int health, int max_health, int dmg, int rüstung, int gold) : base(name, health, dmg)
    	{
    		this.Name = name;
    		this.Health = health;
    		this.Max_health = max_health;
    		this.Dmg = dmg;
    		this.Gold = gold;
    		this.rüstung = rüstung;
    	}
    	public void getsDamaged(int d)
    	{
    		d = d - rüstung;
    		if (Health - d > 0) Health -= d;
    		else Health = 0;
    	}
    	public void heal(int h)
    	{
    		if (Health + h < Max_health) Health += h;
    		else Health = Max_health;
    	}
    	public int Gold
    	{
    		get { return gold; }
    		set { gold = gold + value; }
    	}
    	public int Health { get; set; }
    	public string Name { get; set; }
    	public int Max_health{get;set;}
    	public int Dmg { get; set; }
    	public int Protection { get; set; }
    }   
