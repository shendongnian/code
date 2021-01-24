	public class Test<T> where T: struct, Enum
	{
	    public void Method()
	    {
	        if (!Enum.TryParse<T>("something", out var value))
	            throw new Exception("Oops");
	    }
	}
