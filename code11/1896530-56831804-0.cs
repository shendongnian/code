    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var s = "\"I & my friends are stuck here\", & we can't resolve";
    		Console.WriteLine(
    			Regex.Replace(s, "\"[^\"]*\"", m => Regex.Replace(m.Value, @"\B&\B", "and"))
    		);
    	}
    }
