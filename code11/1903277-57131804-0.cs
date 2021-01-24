using System;
					
public class Program
{
	public static void Main()
	{
		String      str1 = "abcd";
    	String      str2 = "abcd";
		String      str3 = "ABCD";
		
		Console.WriteLine(str1.Equals(str2)); //True
		
		Console.WriteLine(str1.Equals(str3)); //False for upper case
		
		Console.WriteLine(str1.Equals(str3.ToLower())); //True Recommend this because you can compare the user with User and this isn't same.
	}
}
**Documentation:**
https://docs.microsoft.com/es-es/dotnet/api/system.string.equals?view=netframework-4.8#System_String_Equals_System_String_System_String_
