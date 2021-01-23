    interface ICallMe
    {
    	bool A();
    	bool B();
    }
    
    class MyClass
    {
    	public ICallMe Attachment { get; set; }
    
    	public void A()
    	{
    		bool BaseFunction = true;
    		if (Attachment != null)
    			BaseFunction = Attachment.A();
    
    		if (BaseFunction)
    			Console.WriteLine("MyClass.A");
    	}
    
    	public void B()
    	{
    		bool BaseFunction = true;
    		if (Attachment != null)
    			BaseFunction = Attachment.B();
    
    		if (BaseFunction)
    			Console.WriteLine("MyClass.B");
    	}
    }
    
    class ClassA : ICallMe
    {
    	public bool A()
    	{
    		Console.WriteLine("AttachmentA.A");
    		
    		return true;
    	}
    
    	public bool B()
    	{
    		Console.WriteLine("AttachmentA.B");
    
    		return false;
    	}
    }
    
    static class Program
    {
    
    	static void Main(string[] args)
    	{
    		MyClass aaa = new MyClass();
    		aaa.A(); // prints MyClass.A
    		aaa.B(); // prints MyClass.B
    		aaa.Attachment = new ClassA();
    		aaa.A(); // should print AttachmentA.A <newline> MyClass.A
    		aaa.B(); // should print AttachmentB.B
    	}
    }
