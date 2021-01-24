    public class A 
    {
    	public B ClassB { get; private set; }
    	
    	public A()
    	{
    		ClassB = new B(this); //pass the parent class as a parameter
    	}
    	
    	public class B
    	{
    		private A ClassA { get; set; } //With this property you can access the values of class A
    		
    		public B(A _classA)
    		{
    			ClassA = _classA;
    		}
    	}
    }
