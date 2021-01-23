    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace AppendText
    {
    	class Program
    	{
    		public static void Main()
    		{
    			string path = Directory.GetCurrentDirectory() + @"\MyText.txt";
    
    			StreamReader sr1 = File.OpenText(path);
    
    
    			string s = "";
    			int counter = 1;
    			StringBuilder sb = new StringBuilder();
    
    			while ((s = sr1.ReadLine()) != null)
    			{
    				var lineOutput = counter++ + " " + s;
    				Console.WriteLine(lineOutput);
    
    				sb.Append(lineOutput);
    			}
    
    
    			sr1.Close();
    			Console.WriteLine();
    			StreamWriter sw1 = File.AppendText(path);
    			sw1.Write(sb);
    
    			sw1.Close();
    
    		}
    
    	}
    }
