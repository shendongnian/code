    void Main()
    {
    	Dictionary<int, Animal> dictionary = new Dictionary<int, Animal>()
    	{
    		[1] = new Lion(),
    		[2] = new Boar()
    	};
    	
    	IterateTable(dictionary);
    }
    
    public class Animal
    {
    	virtual public void Attack() { Console.WriteLine("Default animal attack"); }
    }
    public class Lion : Animal
    {
    	public override void Attack() { Console.WriteLine("Lion attack"); }
    }
    public class Boar : Animal
    {
    	public override void Attack() { Console.WriteLine("Boar attack"); }
    }
    
    void IterateTable(Dictionary<int, Animal> dictionary)
    {
    	foreach (var entry in dictionary)
    		entry.Value.Attack();
    }
