    IEnumerable<string> RemoveCommaFromEveryOther(IEnumerable<string> parts)
    {
    	using (var partenum = parts.GetEnumerator())
    	{
    		bool replace = false;
    		while (partenum.MoveNext())
    		{
    			if(replace)
    			{
    				yield return partenum.Current.Replace(",","");
    				replace = false;
    			}
    			else
    			{
    				yield return partenum.Current;
    				replace = true;
    			}
    		}
    	}
    }
