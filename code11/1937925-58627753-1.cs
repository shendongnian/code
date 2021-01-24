using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        // This is the input string we are replacing parts from.
        string input = "    WE ARE     THE    CHAMPIONS  MY  FRIEND";
        // Use Regex.Replace to replace the pattern in the input.
        string output = Regex.Replace(input, "\\s+", " ");
        // Write the output.
        Console.WriteLine(input);
        Console.WriteLine(output);
    }
}
**Approach 2:**
To keep inline with your initial question of using Split, Contains, and if, the method Split takes in 3 parameters.
Parameters:
**separator:** It is a character array that delimits the substrings in this string, an empty array that contains no delimiters, or null.
**count:** It is the maximum number of substring to return.
**options:** RemoveEmptyEntries option to omit empty array elements from the array returned or None option to include empty array elements in the array returned.
public String[] Split(char[] separator, int count, StringSplitOptions options);
Hence after making the necessary changes, your final code becomes:
using System;
					
public class Program
{
	public static void Main()
	{
		string input="    WE ARE     THE    CHAMPIONS  MY  FRIEND";
		String[] spearator = {" "}; 
    	String[] input2=input.Split(spearator, 1000, StringSplitOptions.RemoveEmptyEntries); 
		String result="";
    foreach(var item in input2) {
			result+=item+" ";
	}
    Console.WriteLine(result);
	}
}
