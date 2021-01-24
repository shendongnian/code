    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    { 
        private static List<String> excludeFromText = new List<string>() {"and", "he", "the", "to", "is"};
    	private static String textOnBook = "alis and joe went to the store to buy fish and salad salad is joe favorite food";
    
     
    	public static void Main()
    	{
    		Console.WriteLine(string.Join(",", MostUsedWords(textOnBook, excludeFromText)));
    	}
    	
        public static  List<String> MostUsedWords(String textOnBook, List<String> excludeFromText)
        {
            var words = textOnBook.Split(' ');
    
    		return words.GroupBy(z => z)
    					.GroupBy(z => z.Count())
    					.OrderByDescending(z => z.Key)
    					.First()
    					.SelectMany(z => z)
                        .Where(z => z.Length > 0)
    					.Except(excludeFromText)
    					.ToList();
         }
    }
