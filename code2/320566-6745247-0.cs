    using System;
    
    class Program
    {
        static void Main()
        {
    	    string s = "/*there*/ is a cat";
        	string s = "User name (sales)";
            int start = s.IndexOf("/*");
            int end = s.IndexOf(")*/")
            string result = s.substring(start, end - start -1)
            //result contains "there"
        }
    }
