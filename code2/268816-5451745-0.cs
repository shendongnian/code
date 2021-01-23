    using System;
    
    public class TotalPurchase
    {
    	public static void Main()
    	{
    	   double total4 = 0;
    	   double total5 = 0;
    	   double total6 = 0;
    	   
    	   int numberOfInputForTotal4 = 0;
    	   int numberOfInputForTotal5 = 0;
    	   int numberOfInputForTotal6 = 0;
    	   
    	   int myint = -1;
    
    		while (myint != 0)
    		{
    			string group;
    	
    			Console.WriteLine("Please enter group number (4, 5, or 6)");
    			Console.WriteLine("(0 to quit): ");
    			group = Console.ReadLine();
    			myint = Int32.Parse(group);
    	
    			switch (myint)
    			{
    				case 0:
    					break;
    				case 4:
    					double donation4;
    					string inputString4;
    					Console.WriteLine("Please enter the amount of the contribution: ");
    					inputString4 = Console.ReadLine();
    					donation4 = Convert.ToDouble(inputString4);
    					total4 += donation4;
    					numberOfInputForTotal4++;
    					break;
    				case 5:
    					double donation5;
    					string inputString5;
    					Console.WriteLine("Please enter the amount of the contribution: ");
    					inputString5 = Console.ReadLine();
    					donation5 = Convert.ToDouble(inputString5);
    					total5 += donation5;
    					numberOfInputForTotal5++;
    					break;
    				case 6:
    					double donation6;
    					string inputString6;
    					Console.WriteLine("Please enter the amount of the contribution: ");
    					inputString6 = Console.ReadLine();
    					donation6 = Convert.ToDouble(inputString6);
    					total6 += donation6;
    					numberOfInputForTotal6++;
    					break;
    				default:
    					Console.WriteLine("Incorrect grade number.", myint);
    					break;
    			}
    		}
    
    		Console.WriteLine("Grade 4 total is {0}", total4.ToString("C"));
    		Console.WriteLine("Grade 5 total is {0}", total5.ToString("C"));
    		Console.WriteLine("Grade 6 total is {0}", total6.ToString("C"));
    
    		Console.WriteLine("Grade 4 average is {0}", (total4 / numberOfInputForTotal4).ToString("C"));
    		Console.WriteLine("Grade 5 average is {0}", (total5 / numberOfInputForTotal5).ToString("C"));
    		Console.WriteLine("Grade 6 average is {0}", (total6 / numberOfInputForTotal6).ToString("C"));
    	
    	}
    }
