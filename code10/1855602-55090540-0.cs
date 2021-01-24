    public class Program
    {
    	private readonly junk jk;
    	private static readonly junk jk2;
    	
    	public static void Main()
    	{
    		var program = new Program();
    		program.jk.change();
    		Console.WriteLine(program.jk.i); // prints 0
    		jk2.change();
    		Console.WriteLine(jk2.i); // prints 0
    	}
    }
    
    public struct junk
    {
    	public int i;
    	public void change()
    	{
    		i += 1;
    	}
    }
