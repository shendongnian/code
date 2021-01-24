    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str_to_find = "➖➖➖➖➖➖➖➖➖➖\r\n";
    		string str = "Nancy" + str_to_find;
    		if (str.EndsWith(str_to_find)) {
      		  	str = Remove_Last_String(str, str_to_find);
    			Console.WriteLine(str);
    		}
    	}
    	
    	public static string Remove_Last_String(string Source, string Find) {
    
        int i = Find.Length;
        int j = Source.Length;
        if (i >= 0) {
            string new_str = Source.Substring(0, j-i);
            return new_str;
        }
        else return Source;
        }
    }
