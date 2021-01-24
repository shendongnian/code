    // In this solution we don't need to define Multi Cast Delegate explicitly
    // It is automatically initialized and chained
    class Program
    {
        // Main Function 
        static void Main(string[] args)
        {
           // Fetch the MethodInfo array using reflection API
            var powerMembers = typeof(Power).GetMethods(BindingFlags.Public | BindingFlags.Static);
    		
            // Initialize Delegate using first Index
            var del=(Action<int>)Delegate.CreateDelegate(typeof(Action<int>),typeof(Power), powerMembers[0].Name);
    		
            // Add other methods beside first method
    		for(int index = 1; index < powerMembers.Length; index++)
    		{
    			del += (Action<int>)Delegate.CreateDelegate(typeof(Action<int>),typeof(Power), powerMembers[index].Name); 
    		}
    		
            // Execute All
            del(3);
           
        }
    }
    // Made class static, it can also be an instance class and method and you need to apply the BindingFlags in reflection correctly
    static class Power
    {
    	public static void Square(int x) => Console.WriteLine($"The number of {x} to the power of two equals {x * x}" + Environment.NewLine);
	    public static void Cubed(int x) => Console.WriteLine($"The number of {x} to the power of three equals {Math.Pow(x, 3)}" + Environment.NewLine);	
    	public static void xToThePowerOfFour(int x) => Console.WriteLine($"The number of {x} to the power of four equals {Math.Pow(x, 4)}" + Environment.NewLine);
    	public static void xToThePowerOfFive(int x) => Console.WriteLine($"The number of {x} to the power of five equals {Math.Pow(x, 5)}" + Environment.NewLine);
    	public static void xToThePowerOfSix(int x) => Console.WriteLine($"The number of {x} to the power of six equals {Math.Pow(x, 6)}" + Environment.NewLine);
    }
