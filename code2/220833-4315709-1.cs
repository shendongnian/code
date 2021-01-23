    public static string TitleCase(string input, params string[] dontCapitalize) {
       var split = input.Split(' ');
       for(int i = 0; i < split.Length; i++)
    	    split[i] = i == 0 
              ? CapitalizeWord(split[i]) 
              : dontCapitalize.Contains(split[i])
                 ? split[i]
                 : CapitalizeWord(split[i]);
       return string.Join(" ", split);
    }
    public static string CapitalizeWord(string word)
    {
    	return char.ToUpper(word[0]) + word.Substring(1);
    }
