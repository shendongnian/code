    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute {
    	public MyAttribute(Type[] exceptionList) {
    	}
    }
    
    [MyAttribute(new Type[] { typeof(ArgumentException), typeof(OtherException) } )]
    class Test {
    	...
    }
