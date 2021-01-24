    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		    var sentence = "case is for instance doooo mapping code to some data source or third party API that where the names are used as keys. The method uses “static reflection”, or rather it parses the expression tree from a lambda expression, to figure out the name of a property that the lambda expression returns the value of.Look, good against remotes is one thing, good against the living, that’s something else.For several years I’ve had a little “utility” function that I’ve used in several projects that I use to convert property names into strings. One use case is for instance when mapping code to some data source or third party API that where the names are used as keys. The method uses “static reflection”, or rather it parses the expression tree from a lambda expression, to figure out the name of a property that the lambda expression returns the value of.Look, good against remotes is one thing, good against the living, that’s something else.";
                var keyword = "instance";
    
                int wordFreq = 2;
                var words = sentence.Split(' ').ToArray(); // split into words
                int foundndex = Array.FindIndex(words, w => w.Equals(keyword)); // find the index within
                                                                                // take wordFreq words from wordFreq before the index of your keyword
                var wordsArray = Enumerable
                        .Range((foundndex - wordFreq) > 0 ? (foundndex - wordFreq) : 0, (wordFreq*2+1 > (words.Length)-1) ? (words.Length)-1 : wordFreq*2+1 )
                        .Select(i => words[i]).ToArray();            
    
    			var outPut = string.Join(" ", wordsArray);
                
    		    Console.WriteLine("Output:- {0} ",outPut);				
    	}
    }
