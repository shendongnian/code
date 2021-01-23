    public sealed class Program
    {
    	private readonly int _number1;
    	private readonly int _number2;
    
    	public Program(int number1, int number2)
    	{
    		this._number1 = number1;
    		this._number2 = number2;
    	}
    
    	public int Sum()
    	{
    		return this._number1 + this._number2;
    	}
    
    	public static void Main(string[] args)
    	{
    		// this one here is really brutal, but you can adapt it
    		int number1 = int.Parse(args[0]);
    		int number2 = int.Parse(args[1]);
    		Program program = new Program(number1, number2);
    		int sum = program.Sum();
    		Console.WriteLine(sum);
    		Console.ReadLine();
    	}
    }
