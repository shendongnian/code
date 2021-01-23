    public IEnumerable<string> GetPossibleWords(char[,] letters)
    {
    	return
    		from ws in this.GetPossibleWordLists(letters)
    		from w in ws
    		select w;
    }
    
    private IEnumerable<IEnumerable<string>> GetPossibleWordLists(char[,] letters)
    {
    	Func<int, int> inc = x => x + 1;
    	Func<int, int> nop = x => x;
    	Func<int, int> dec = x => x - 1;
    	for (var r = letters.GetLowerBound(0);
    		r <= letters.GetUpperBound(0); r++)
    	{
    		for (var c = letters.GetLowerBound(1);
    			c <= letters.GetUpperBound(1); c++)
    		{
    			yield return new [] { letters[r, c].ToString(), };
    			yield return this.GetPossibleWords(letters, r, c, dec, dec);
    			yield return this.GetPossibleWords(letters, r, c, inc, dec);
    			yield return this.GetPossibleWords(letters, r, c, nop, dec);
    			yield return this.GetPossibleWords(letters, r, c, dec, nop);
    			yield return this.GetPossibleWords(letters, r, c, inc, nop);
    			yield return this.GetPossibleWords(letters, r, c, nop, inc);
    			yield return this.GetPossibleWords(letters, r, c, dec, inc);
    			yield return this.GetPossibleWords(letters, r, c, inc, inc);
    		}
    	}
    }
    
    private IEnumerable<string> GetPossibleWords(char[,] letters,
    	int r, int c,
    	Func<int, int> rd, Func<int, int> cd)
    {
    	var chars = new List<char>();
    	while (r >= letters.GetLowerBound(0) && r <= letters.GetUpperBound(0)
    		&& c >= letters.GetLowerBound(1) && c <= letters.GetUpperBound(1))
    	{
    		chars.Add(letters[r, c]);
    		if (chars.Count > 1)
    		{
    			yield return new string(chars.ToArray());
    		}
    		r = rd(r);
    		c = cd(c);
    	}
    }
