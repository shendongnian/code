    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DateTime dt = DateTime.ParseExact("21/10/2018 04:08:23", "dd/MM/yyyy HH:mm:ss", null);
    		Console.WriteLine(dt.ToString("MMddyyyy"));
    	}
    }
