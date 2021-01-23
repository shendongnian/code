    using System;
    internal class WithPublic
    {
	    public WithPublic() { }
    }
    
    internal class WithInternal
    {
	    internal WithInternal() { }
    }
    
    public class Program
    {
	    public static void Main()
    	{
	    	Console.WriteLine(typeof(WithPublic).GetConstructor(new Type[] { }) == null); //false
    		Console.WriteLine(typeof(WithInternal).GetConstructor(new Type[] { }) == null); //true
	    }
    }
