    class Program
    {
    
        static void Main(string[] args)
        {
           
            var powerMembers = typeof(Power).GetMethods(BindingFlags.Public | BindingFlags.Static);
    		
            var del=(Action<int>)Delegate.CreateDelegate(typeof(Action<int>),typeof(Power), powerMembers[0].Name); //error
    		
    		for(int index = 1; index < powerMembers.Length; index++)
    		{
    			del += (Action<int>)Delegate.CreateDelegate(typeof(Action<int>),typeof(Power), powerMembers[index].Name); 
    		}
    		
            del(3);
           
        }
    }
    static class Power
    {
    	public static void Cubed(int x) => Console.WriteLine($"The number of {x} to the power of three equals {Math.Pow(x, 3)}" + Environment.NewLine);
    	public static void Square(int x) => Console.WriteLine($"The number of {x} to the power of two equals {x * x}" + Environment.NewLine);	
    	public static void xToThePowerOfFour(int x) => Console.WriteLine($"The number of {x} to the power of four equals {Math.Pow(x, 4)}" + Environment.NewLine);
    	public static void xToThePowerOfFive(int x) => Console.WriteLine($"The number of {x} to the power of five equals {Math.Pow(x, 5)}" + Environment.NewLine);
    	public static void xToThePowerOfSix(int x) => Console.WriteLine($"The number of {x} to the power of six equals {Math.Pow(x, 6)}" + Environment.NewLine);
    }
