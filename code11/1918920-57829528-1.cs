    struct Baz : IBar
    {
    	public void CallFoo()
    	{
	        this.AsBar().Foo();
    	}
        public IBar AsBar()
    	{
	        return this;
    	}
    }
