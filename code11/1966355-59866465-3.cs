    using System;
    
    public class Program
    {
    	
    	public static string Capitalize(string s)
    	{
    		if(string.IsNullOrEmpty(s))
    			return string.Empty;
    		
    		string result = char.ToUpper(s[0]) + s.Substring(1);
    		
    		return result;
    	}
    	
    	public static void Main()
    	{
                string firstName;
                string lastName;
    
                Console.WriteLine("What is your First Name?");
                firstName = Console.ReadLine();
                Console.WriteLine("What is your Last Name?");
                lastName = Console.ReadLine();
    		
    			firstName = Capitalize(firstName);
    			lastName = Capitalize(lastName);
    			Console.Write("Hello, {0} {1}.", firstName, lastName);
    	}
    }
