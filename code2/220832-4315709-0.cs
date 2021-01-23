    string TitleCase(string input, params string[] dontCapitalize) {
       var split = input.Split(' ');
       for(int i = 0; i < split.Length; i++)
       {
          switch(i)
    	  {
    	  case 0:
    	    split[0] = CapitalizeWord(split[0]);
    	    break;
    	  default:
    	    split[i] = dontCapitalize.Contains(split[i])
    	      ? split[i]
    	      : CapitalizeWord(split[i]);
    	    break;
          }
       }
       return string.Join(" ", split);
    }
    string CapitalizeWord(string word)
    {
    	return char.ToUpper(word[0]) + word.Substring(1);
    }
