    public static IEnumerable<string> SmartSplit(this string input, int maxLength)
    {
	    int i = 0;
	    while(i + maxLength < input.Length)
	    {
		    int index = input.LastIndexOf(' ', i + maxLength);
                 if(index<=0) //if word length > maxLength.
				{
					index=maxLength;
				}
		    yield return input.Substring(i, index - i);
		    i = index + 1;
	    }
	    yield return input.Substring(i);
    }
