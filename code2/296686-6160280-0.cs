    string str = ":My name is Joe";
    
    var letterDictionary = new Dictionary<char,int>();
    
    foreach (char c in str) {
    	// Filtering non-letter characters
    	if (!char.IsLetter(c))
    		continue;
    	
    	// We use lowercase letter as a comparison key
    	// so "M" and "m" are considered the same characters
    	char key = char.ToLower(c);
    	
    	// Now we try to get the number of times we met
    	// this key already.
    	// TryGetValue method will only affect charCount variable
    	// if there is already a dictionary entry with this key,
    	// otherwise its value will be set to default (zero)
    	int charCount;
    	letterDictionary.TryGetValue(key, out charCount);
    	
    	// Either way, we now have to increment the charCount value
    	// for our character and put it into dictionary
    	letterDictionary[key] = charCount + 1;	
    }
    
    foreach (var kvp in letterDictionary) {
    	Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
    }
