    using System.Text.RegularExpressions;
    public static string RemoveFromList(this string sentence)
    {
    	new List<string>{ "ask-", 
						 "que-", 
						 "(app)", 
						 "(exe)", 
						 "(foo)" }.ForEach(name => 
										   {
											   sentence = Regex.Replace(sentence.Replace(name, string.Empty), " {2,}", " ");
										   });			
		return sentence;
    }
