    using System;
    using System.Text;
    
    public class Program
    {
    	//This method is created to read input from users and convert it to number
    	static double readnum()
    	{
    		string inp = Console.ReadLine();
    		double res;
    		while (!double.TryParse(inp, out res)) // add check for negative value
    		{
    			Console.WriteLine("Sorry, you need value in digits");
    			inp = Console.ReadLine();
    		}
    
    		Console.WriteLine(res);
    		return res;
    	}
    
    	public static void Main()
    	{
    		// Get the Flow value from thre user
    		Console.WriteLine("Please Enter the value of Flow in m3/hr");
    		double flox = readnum();
    		// Get the Velocity value from the user
    		Console.WriteLine("Please Enter the value of velcoty in m/s");
    		double velx = readnum();
    		double dd = (4 * flox) / (Math.PI * velx); //
    		double d = Math.Sqrt(dd);
    		Console.WriteLine("The diameter required for the pipe is " + d);
    		Console.ReadLine();
    	}
    }
