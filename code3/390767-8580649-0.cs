    using System.Linq;
    
    public class Class1
    {
    	public Class1()
    	{
    	    string s =
    	        @"\RBsDC\1031\2011\12\40\1031-215338-5DRH44PUEM2J51GRL7KNCIPV3N-META-ENG-22876500BBDE449FA54E7CF517B2863E.XML";
    
    	    var array = s.Split('\\');
    
    	    string value = array.Last();
    	}
    }
