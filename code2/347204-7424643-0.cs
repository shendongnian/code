    static void Main(string[] args)
    {
    	Console.WriteLine("Animal: {0}", new Animal().NumberOfLegs);
    	Console.WriteLine("Caterpillar: {0}", new Caterpillar().NumberOfLegs);
    
    	Console.ReadKey();
    }
    
    public class Animal
    {
    	public int NumberOfLegs { get { return 1; } }
    }
    
    public class Caterpillar : Animal
    {
    	public new int NumberOfLegs { get { return 100; } }
    }
