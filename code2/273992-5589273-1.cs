        class MyClass
    {
    	private ClassThing Thing1;
    	private ClassThing Thing2;
    	private ClassThing Thing3;
    
    	internal IEnumerable<ClassThing> GetThings()
    	{
    			yield return Thing1;
    			yield return Thing2;
    			yield return Thing3;
    	}
    	void Test()
    	{
    		foreach(var thing in this.GetThings())
    		{
    			//use thing
    		}
    	}
    }
