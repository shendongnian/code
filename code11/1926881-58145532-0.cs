      using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		decimal decimalNumber = 0.26579M;
     		int decimalPosition =3;
     		int decimalPositionValue = 0;
    		Console.WriteLine(getdecimalPositionValue(decimalNumber, decimalPosition));
    	}
    	
    
    
    	public static int getdecimalPositionValue(decimal num, int pos)
    	{
    	return int.Parse(num.ToString().Split('.')[1].Substring(pos -1, 1));
    	}
    }
