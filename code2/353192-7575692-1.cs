	using System;
	public class MyClass
	{
		public static void Main()
		{
			short myShort = 23948;
			byte myByte = (byte)myShort; // ok
			myByte = myShort; // error: 
	
			Console.WriteLine("Short: " + myShort);
			Console.WriteLine("Byte:  " + myByte);
			
			myShort = myByte; // ok
			
			Console.WriteLine("Short: " + myShort);
		}
	}
