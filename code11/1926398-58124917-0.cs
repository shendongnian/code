using System;
					
public class Program
{
	public static void Main()
	{
		string BarCode="000001661705";
	
             char pad = '0';
            if(BarCode.Length==12)
            {
                BarCode = pad + BarCode;
        
  
            }
		Console.WriteLine("Length of barcode" + BarCode.Length);
		Console.WriteLine("Barcode=" + BarCode);
		
	}
}
