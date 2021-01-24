    class Kingdom
    {
    	private bool milk, wings, fruits;
    
    	public Kingdom() : this(true, true, true) { }
    	public Kingdom(bool m, bool w, bool f)
    	{
    		milk = m;
    		wings = w;
    		fruits = f;
    	}
    
    	public virtual string me()
    	{
    		return "Kingdom Member";
    	}
    	
    	protected virtual bool GetMilk() => milk;
    	protected virtual bool GetWings() => wings;
    	protected virtual bool GetFruits() => fruits;
    
    	public virtual void Fly()
    	{
    		if (GetWings())
    		{
    			Console.WriteLine(me() + " may Fly.");
    		}
    		else
    		{
    			Console.WriteLine(me() + " can not Fly.");
    		}
    	}
    
    	public virtual void Fruit()
    	{
    		if (GetFruits())
    		{
    			Console.WriteLine(me() + " may bear Fruits.");
    		}
    		else
    		{
    			Console.WriteLine(me() + " can not bear Fruits.");
    		}
    	}
    
    	public virtual void Milk()
    	{
    		if (GetMilk())
    		{
    			Console.WriteLine(me() + " may produce milk.");
    		}
    		else
    		{
    			Console.WriteLine(me() + " can not produce milk.");
    		}
    	}
    }
    
    class Plant : Kingdom
    {
    	private bool milk, wings, fruits;
    
    	public Plant()
    	{
    		milk = false;
    		wings = false;
    		fruits = true;
    	}
    
    	public override string me()
    	{
    		return "Plants";
    	}
    
    	protected override bool GetMilk() => milk;
    	protected override bool GetWings() => wings;
    	protected override bool GetFruits() => fruits;
    }
    
    class Animelia : Kingdom
    {
    	private bool milk, wings, fruits;
    
    	public Animelia()
    	{
    		milk = true;
    		wings = true;
    		fruits = false;
    	}
    
    	public override string me()
    	{
    		return "Animals";
    	}
    
    	protected override bool GetMilk() => milk;
    	protected override bool GetWings() => wings;
    	protected override bool GetFruits() => fruits;
    }
    
    class Mamalia : Animelia
    {
    	private bool milk, wings, fruits;
    
    	public Mamalia()
    	{
    		milk = true;
    		wings = false;
    		fruits = false;
    	}
    
    	public override string me()
    	{
    		return "Mamals";
    	}
    
    	protected override bool GetMilk() => milk;
    	protected override bool GetWings() => wings;
    	protected override bool GetFruits() => fruits;
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		Console.WriteLine("Hello World!\nLets learn Basic Kingdoms.\n");
    
    		Kingdom p1 = new Plant();
    		Kingdom m1 = new Mamalia();
    
    		p1.Fly();
    		p1.Milk();
    		p1.Fruit();
    		Console.WriteLine();
    		m1.Fly();
    		m1.Milk();
    		m1.Fruit();
    	}
    }
