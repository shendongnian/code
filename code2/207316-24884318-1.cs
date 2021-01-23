    using System.Collections.Generic;		
		
    public static char firstNonRepeatedChar(string str)
    {
        if (str == null || str =="")
            return '\0';
		    
        Dictionary<char, int> dictionaryObject = new Dictionary<char, int>();
        for (int i = 0; i< str.Length ; i++)
        {
            if (dictionaryObject.ContainsKey((str[i])))
            {
                int outValue = 0;
                dictionaryObject.TryGetValue((str[i]),out outValue);
                dictionaryObject[(str[i])] = outValue + 1;
            }
            else
            {
                dictionaryObject.Add(str[i],1);
            }
        }
        foreach (var outputChar in dictionaryObject)
        {
            if (outputChar.Value == 1)
                return outputChar.Key;
        }
        return '\0';
    }
