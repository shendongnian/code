    public static string RemoveFromList(this string sentence)
    {
    	new List<string>{ "ask-", 
						 "que-", 
						 "(app)", 
						 "(exe)", 
						 "(foo)" }.ForEach(name => 
										   {
											   sentence = sentence.Replace(name, string.Empty);
										   });			
		return sentence;
    }
