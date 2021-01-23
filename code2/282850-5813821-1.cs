	void Main()
	{
		MyFunc(1)(2)(3)(4);
	}
	
	delegate F<T> F<T>(T obj);
	
	F<T> MyFunc<T>(T obj)
	{
		Console.WriteLine(obj);
		return MyFunc;
	}
