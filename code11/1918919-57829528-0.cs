    struct Baz : Bar
    {
    	public void CallFoo()
    	{
	        this.AsBar().Foo();
    	}
        public Bar AsBar()
    	{
	        return this;
    	}
    }
