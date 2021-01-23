    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Collections;
    
    public class MyClass
    {
    	public static void ProcessFile()
    	{
    		TextReader textReader = new StreamReader(@"C:\DEV\DATA\MyDataFile.txt");
    		string s = textReader.ReadLine();  
    		string col1 = s.Substring(9, 29).Trim();  
    		
    		s = textReader.ReadLine();  
    		string col2 = s.Substring(9, 29).Trim();  
    		
    		s = textReader.ReadLine();  
    		string col3 = s.Substring(9, 29).Trim();  
    		
    		s = textReader.ReadLine();  
    		string col4 = s.Substring(9, 29).Trim();
    		
    		
    		s = textReader.ReadLine();
    		s = textReader.ReadLine();
    		s = textReader.ReadLine();
    		s = textReader.ReadLine();
    		s = textReader.ReadLine();
    		s = textReader.ReadLine();
    
    		s = textReader.ReadLine();  
    		string col5 = s.Split(",")[0].Trim();
    		string col6 = s.Split(",")[1].Trim();
    		
    		while ((s = textReader.ReadLine()).Trim() != "")
    		{
    			string LoadingContainer = s.Substring(0, 10).Trim();  
    			string DischargeSeal = s.Substring(13, 23).Trim();  
    			string Dest  = s.Substring(25, 25).Trim();
    			// Parse further colums here...
    			// Insert record into the database
    		}
    	}
    	
    	public static void Main()
    	{
    		try
    		{
    			ProcessFile();
    		}
    		catch (Exception e)
    		{
    			string error = string.Format("---\nThe following error occurred while executing the program:\n{0}\n---", e.ToString());
    			Console.WriteLine(error);
    		}
    		finally
    		{
    			Console.Write("Press any key to continue...");
    			Console.ReadKey();
    		}
    	}
    
    }
