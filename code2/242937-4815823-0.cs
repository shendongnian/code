    class A {
    	public int Foo { get; set; }
    	public int Bar { get; set; }
    
    	public A() { }
    
    	public A(A a) {
    		Foo = a.Foo;
    		Bar = a.Bar;
    	}
    }
    
    class B : A {
    	public int Hello { get; set; }
    
    	public B()
    		: base() {
    
    	}
    
    	public B(A a)
    		: base(a) {
    
    	}
    }
