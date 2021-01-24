using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter a year ");
		//Console.ReadLine returns the entered data as a string
        var yearString = Console.ReadLine();
		//Convert the string to an int
		int year = Int32.Parse(yearString);
		
		//Now we can call your function, passing the year variable and recording the bool value passed back
		var isLeapYearAnswer = IsLeapYear(year);
		//Print the answer to the console
		Console.WriteLine(isLeapYearAnswer);
	}
	
	public static bool IsLeapYear(int year)
    { 
		if (year % 4 == 0 && year % 100 != 0 || year % 400 ==0)
            {
                return true;
            }
		else
		{
            return false;
		}
    }
}
Here's a [dotnetfiddle][1]
  [1]: https://dotnetfiddle.net/bDDudm
