    public class FooAttribute : Attribute {
        	public bool? SomeFlag { get; set; }
        
        	public bool SetSomeFlag {
    		get {
    			throw new Exception("should not be called"); // required for property visibility
    		}
    		set {
    			SomeFlag = value;
    		}
    	}
    }
    
    [Foo(SetSomeFlag=true)]
    public class Person {
    }
    
    [Foo]
    public class Person2 { // SetSomeFlag is not set
    }
    bool? b1 = ((FooAttribute)typeof(Person).GetCustomAttributes(typeof(FooAttribute), false)[0]).SomeFlag; // b1 = true
   	bool? b2 = ((FooAttribute)typeof(Person2).GetCustomAttributes(typeof(FooAttribute), false)[0]).SomeFlag; // b2 = null
