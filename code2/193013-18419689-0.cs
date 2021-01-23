    [TestMethod]
    public void StringEqualsMethodVsOperator()
    {
    	string s1 = new StringBuilder("string").ToString();
    	string s2 = new StringBuilder("string").ToString();
    
    	Debug.WriteLine("string a = \"string\";");
    	Debug.WriteLine("string b = \"string\";");
    
    	TryAllStringComparisons(s1, s2);
    
    	s1 = null;
    	s2 = null;
    
    	Debug.WriteLine(string.Join(string.Empty, Enumerable.Repeat("-", 20)));
    	Debug.WriteLine(string.Empty);
    	Debug.WriteLine("string a = null;");
    	Debug.WriteLine("string b = null;");
    
    	TryAllStringComparisons(s1, s2);
    }
    private void TryAllStringComparisons(string s1, string s2)
    {
    	Debug.WriteLine(string.Empty);
    	Debug.WriteLine("-- string.Equals --");
    	Debug.WriteLine(string.Empty);
    	Try((a, b) => string.Equals(a, b), s1, s2);
    	Try((a, b) => string.Equals((object)a, b), s1, s2);
    	Try((a, b) => string.Equals(a, (object)b), s1, s2);
    	Try((a, b) => string.Equals((object)a, (object)b), s1, s2);
    
    	Debug.WriteLine(string.Empty);
    	Debug.WriteLine("-- object.Equals --");
    	Debug.WriteLine(string.Empty);
    	Try((a, b) => object.Equals(a, b), s1, s2);
    	Try((a, b) => object.Equals((object)a, b), s1, s2);
    	Try((a, b) => object.Equals(a, (object)b), s1, s2);
    	Try((a, b) => object.Equals((object)a, (object)b), s1, s2);
    
    	Debug.WriteLine(string.Empty);
    	Debug.WriteLine("-- a.Equals(b) --");
    	Debug.WriteLine(string.Empty);
    	Try((a, b) => a.Equals(b), s1, s2);
    	Try((a, b) => a.Equals((object)b), s1, s2);
    	Try((a, b) => ((object)a).Equals(b), s1, s2);
    	Try((a, b) => ((object)a).Equals((object)b), s1, s2);
    
    	Debug.WriteLine(string.Empty);
    	Debug.WriteLine("-- a == b --");
    	Debug.WriteLine(string.Empty);
    	Try((a, b) => a == b, s1, s2);
    #pragma warning disable 252
    	Try((a, b) => (object)a == b, s1, s2);
    #pragma warning restore 252
    #pragma warning disable 253
    	Try((a, b) => a == (object)b, s1, s2);
    #pragma warning restore 253
    	Try((a, b) => (object)a == (object)b, s1, s2);
    }
    public void Try<T1, T2, T3>(Expression<Func<T1, T2, T3>> tryFunc, T1 in1, T2 in2)
    {
    	T3 out1;
    
    	Try(tryFunc, e => { }, in1, in2, out out1);
    }
    public bool Try<T1, T2, T3>(Expression<Func<T1, T2, T3>> tryFunc, Action<Exception> catchFunc, T1 in1, T2 in2, out T3 out1)
    {
    	bool success = true;
    	out1 = default(T3);
    
    	try
    	{
    		out1 = tryFunc.Compile()(in1, in2);
    		Debug.WriteLine("{0}: {1}", tryFunc.Body.ToString(), out1);
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine("{0}: {1} - {2}", tryFunc.Body.ToString(), ex.GetType().ToString(), ex.Message);
    		success = false;
    		catchFunc(ex);
    	}
    
    	return success;
    }
