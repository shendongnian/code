foreach(int number in "money.txt"){
    int sum = number + number; // BIG ERROR
    label5.Text = sum.ToString();
}
You have make a big mistake with `int sum = number + number;`.
Take `sum` to out of your scope (maybe `global`) first.
You have to do 2 steps:
Try this online [here](https://dotnetfiddle.net/C4sYU7)
Step 1: Read content of your file:
using System.IO;
// Your code
static string yourTextFileContent = File.ReadAllText("money.txt");
Step 2: I wrote a method to do your work:
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
					
public class Program
{
    // Demo string
    static string yourMoney = @"28:Toy
1:Chocolate bar
10:Water bottle";
    // Your real string
    //static string yourTextFileContent = File.ReadAllText("money.txt");
	public static void Main()
	{
		Console.WriteLine("Using IEnumerable");
        // int sum = 0;
		foreach (int item in GetEnumerableIntFromString(yourMoney))
		{
            sum += item;
			Console.WriteLine(item);
		}
        Console.WriteLine($"Sum: {sum}");
        //label5.Text = sum.ToString();
	}
	
	// Using IEnumerable
	private static IEnumerable<int> GetEnumerableIntFromString(string str)
	{
        string[] splitLine = str.Split(new[]{'\r','\n'},StringSplitOptions.RemoveEmptyEntries);
		foreach(string item in splitLine)
		{
			string[] splitToGetNumber = item.Split(new[]{':'},StringSplitOptions.RemoveEmptyEntries);
			yield return Convert.ToInt32(splitToGetNumber[0].Trim());
		}
	}
}
If you have an `Enumerable`, you want to Convert to `List`:
Enumerable<int> enumerable = yourEnumerable;
List<int> asList = enumerable.ToList();
