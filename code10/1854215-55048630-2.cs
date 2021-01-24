    class C
    {
       // Obviously you want to encapsulate these as properties, not fields
       public string a;
       public string b;
    
       public static implicit operator C(string s)
       {
    	  var localA = s.Substring(0, 2);
          var localB = s.Substring(3);
    	  return new C
    	  {
    	     a = localA,
    		 b = localB
    	  };
       }
    }
    
    void Main()
    {
    	C myC = "AA BBBBBBBB"; // Or explicitly, var myC = (C)"AA BBBBBBBB"
    	Console.WriteLine(myC.a);
    	Console.WriteLine(myC.b);
    }
