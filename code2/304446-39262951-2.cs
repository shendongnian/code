    public delegate void MyByRefConsumer<T>(ref T val);
    public void DoSomethingWithValueType(MyByRefConsumer<int> c)
	{
			int x = 2;
			c(ref x);
            //Handle potentially changed x...
	}
