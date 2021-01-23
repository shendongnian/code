    using System;
    using System.Collections.Generic;
    
    public class MyClass
    {
    	public static void Main()
    	{
    		var dict = new Dictionary<int, Member>();
    		dict.Add(123, new Member("Jonh"));
    		dict.Add(908, new Member("Andy"));
    		dict.Add(456, new Member("Sarah"));
    		
    		dict[456].City = "London";
    		
    		Console.WriteLine(dict[456].MemberName  + " " + dict[456].City);
    		Console.ReadKey();
    	}
    }
    
    public class Member
    {
    	public Member(string name) {MemberName = name; City="Austin";}
    	public string MemberName { get; set; }
    	public string City { get; set; }
    	// etc...
    }
