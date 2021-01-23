    public class A
    {
    	B b = new B();
    
        public A()
    	{
    	   b.SomethingHappened += SomethingHappenedHandler; 
    	}
    	public void resetValues()
    	{
    		//DoSomething
    	}
    	public void SomethingHappenedHandler(object sender, EventArgs args)
    	{
    		resetValues();
    	}
    
    }
