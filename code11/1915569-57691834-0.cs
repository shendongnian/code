    using System;
    using System.Threading;
    namespace Infinite_Donkey
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			Console.WriteLine("EN : Press 'Enter' and wait to see the magic!");
    			Console.WriteLine("TR : 'Enter' tuşuna basip bekle.");
    			Console.Read();
    			Console.WriteLine("            ^__^");
    			Console.WriteLine("            (oo)_______");
    			Console.WriteLine("            (__)       )\\");
    			Console.WriteLine("                ||---||  ");
    			Console.WriteLine("                ||   ||  ");
    			Thread.Sleep(2000);
    			do
    			{
    				Console.WriteLine("                ||   ||");
    				Thread.Sleep(100);
    			}while(true);
    		}
    	}
    }
