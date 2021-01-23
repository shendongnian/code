    public string DoSomething(Expression<Func<int>> expression)
    {
    	//...
    }
    
    public void CallDoSomething()
    {
    	var myObj = new MyType();
    	var result = CallHelper(myObj);
    }
    
    private string CallHelper(MyType m)
    {
    	return DoSomething(() => m.IntProperty);
    }
