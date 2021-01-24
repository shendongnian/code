    public delegate void GetIntegersPower(int x);
	public static void Main()
	{
		var powerMembers = typeof(Power).GetMethods(BindingFlags.Public | BindingFlags.Static);
		GetIntegersPower del  = null;
		foreach(var powerMember in powerMembers)
		{
			del+=(GetIntegersPower)Delegate.CreateDelegate(typeof(GetIntegersPower), powerMember);             
		}
		
		del(3);
	}
	public class Power
    {
        public static void Square(int x) => Console.WriteLine($"The number of {x} to the power of two equals {x * x}" + Environment.NewLine);
        public static void Cubed(int x) => Console.WriteLine($"The number of {x} to the power of three equals {Math.Pow(x,3)}" + Environment.NewLine);
        public static void xToThePowerOfFour(int x) => Console.WriteLine($"The number of {x} to the power of four equals {Math.Pow(x,4)}" + Environment.NewLine);
        public static void xToThePowerOfFive(int x) => Console.WriteLine($"The number of {x} to the power of five equals {Math.Pow(x,5)}" + Environment.NewLine);
        public static void xToThePowerOfSix(int x) => Console.WriteLine($"The number of {x} to the power of six equals {Math.Pow(x,6)}" + Environment.NewLine);
    }
