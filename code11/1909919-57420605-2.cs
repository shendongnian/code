    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    	Console.Write("Mata in antal mjökpaket som är kvar: ");
    	int mjölkpaket = int.Parse(Console.ReadLine()); 
    	if (mjölkpaket < 10) { 
    		Console.WriteLine("Beställ 30 paket"); 
    	}
    	else if (mjölkpaket >= 10 && mjölkpaket <= 20) 
    	{ 
    		Console.WriteLine("Beställ 20 paket"); } 
    	else { 
    		Console.WriteLine("Behöver inte beställa någon mjölk"); } 
    		Console.WriteLine(); 
    		Console.WriteLine("Tryck på enter för att avsluta"); 
    		Console.ReadLine();
    	}
    }
