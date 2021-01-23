    using System.IO;
    
    namespace ConsoleApplication2
    {
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    			var fs = new FileStream(@"C:\Bar.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
    			fs.Write(System.Text.Encoding.ASCII.GetBytes("abc"),0,3);
    			fs.Flush();
    			fs.Close(); //<-- Breakpoint here
    		}
    	}
    }
