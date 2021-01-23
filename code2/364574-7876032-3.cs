    // This works with all kind of lists, but since it is a more general purpose method it will call the virtual method.	
	public void MyMethod(MySpecialListBase list)
	{
	    Console.WriteLine(list.Count());
	}
	
	// This works only with MySpecialArrayList, and will use the optimized method.
	public void MyMethod(MySpecialArrayList list)
	{
	    Console.WriteLine(list.Count());
	}
