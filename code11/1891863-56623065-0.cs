    // .COM
    [ComVisible(true)]
    public object GetSomeStringsForCom()
    {
    	return GetSomeStrings.Cast<object>().ToArray();
    }
    
    // .Net
    ComVisible(false)]
    public IEnumerable<string> GetSomeStrings()
    {
    	IList<string> retval = new List<string>();
    	retval.Add("hello 1");
    	retval.Add("hello 2");
    	retval.Add("hello 3");
    	return retval.ToArray();
    }
