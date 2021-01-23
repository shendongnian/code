	public static class ActionExtensions
	{
		public static Action WrapWithMyCustomHandling(this Action action)
		{
			return () =>
			       	{
			       		try
			       		{
			       			action();
			       		}
			       		catch (Exception exception)
			       		{
			       			
			       			// do what you need 
			       		}
			       	};
		}
	}
    public class DummyClass
    {
    	public void DummyMethod()
    	{
    		throw new Exception();
    	}
    }
