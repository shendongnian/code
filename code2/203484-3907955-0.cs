    using System; 
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace WaitForExit
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			new Thread(() =>
    				{
    					Console.ReadLine();
    					Environment.Exit(0);
    				}).Start();
    
    			int i = 0;
    			while (true)
    			{
    				Console.Clear();
    				Console.WriteLine(++i);
    				Thread.Sleep(1000);
    			}
    		}
    	}
    }    
