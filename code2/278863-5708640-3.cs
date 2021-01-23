    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string content = "Hello\r\n\r\n\r\nThis is my\r\nTest\r\n\r\n\r\n\r\n\r\n\r\nPeanut\r\n\r\nCase\r\n\r\n\r\n\r\n\r\n";
    
    			Console.WriteLine("Here is the unmodified string:");
    			Console.WriteLine();
    			Console.WriteLine(content);
    
    			content = Regex.Replace(content, @"(\r\n){2,}", "<br /><br />");
    			content = Regex.Replace(content, @"\r\n", "<br />");
    
    			Console.WriteLine("Here is the modified string:");
    			Console.WriteLine();
    			Console.WriteLine(content);
    
    			Console.ReadLine();
    		}
    	}
    }
