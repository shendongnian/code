    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string textToReplace = @"Replace this sentence because i dont like it.";
    		string text = @"This is text
                    i want
                    to keep
                        but
                    Replace this sentence
                    because i dont like it.";
    		
    		text = Regex.Replace(text, @"\s+", " ", RegexOptions.Multiline);
    		text = text.Replace(textToReplace, string.Empty);
    		Console.WriteLine(text);
    	}
    }
