    public class Foo
    {
    	public int FileCounter;
    	
    	public void SomeMethod()
    	{
    		FileCounter++;
    	}
    }
    
    public class Bar
    {
    	public void SomeMethod()
    	{
    		var foo = new Foo();
    		foo.SomeMethod();
    		
    		Debug.WriteLine( string.Format("FileCounter: {0}", foo.FileCounter ) );
    	}
    }
