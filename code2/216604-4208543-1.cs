    public class Animal
    {
    	public static Animal Load(string row)
    	{
    		if (row == "Zebra")
    		{
    			return new Zebra();
    		}
    		else if (row == "Elephant")
    		{
    			return new Elephant();
    		}
    
    		return null;
    	}
    }
    
    public class Zebra : Animal
    {
    	public new string ToString()
    	{
    		return "Zebra";
    	}
    }
    
    public class Elephant : Animal
    {
    	public new string ToString()
    	{
    		return "Elephant";
    	}
    }
    
    static void Main(string[] args)
    {
    	Animal a1 = Animal.Load("Zebra");
    	System.Console.WriteLine(((Zebra)a1).ToString());
    
    	System.Console.WriteLine(((Elephant)a1).ToString()); // Exception
    
    	Animal a2 = Animal.Load("Elephant");
    	System.Console.WriteLine(a2.ToString());
    }
