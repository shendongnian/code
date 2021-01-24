	public void UnitTest()
	{            
		Action<MyParent> processor; // Not Action<MyChild>
		processor = DoSomethingBy_MyChild;
		processor(new MyChild());             // OK
		processor = DoSomethingBy_MyParent; 
		processor(new MyChild());             // OK
		processor = DoSomethingBy_MyParent;
		processor(new MyParent());            // OK
	}
