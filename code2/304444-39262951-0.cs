    public delegate void MyByRefConsumer<T>(ref T val);
    public void doSomethingWithValueType(MyByRefConsumer<int> c)
	{
			int x = 2;
			c(ref x);
	}
