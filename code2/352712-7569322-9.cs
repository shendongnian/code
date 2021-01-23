    class A
    {
        public C Test { get; set; }
    }
    class B : A
    {
        public new D Test { get; set; }
    }
    class C {}
    class D : C {}
	...
	static A GetA()
	{
		return new B();
	}
	static C GetC()
	{
		return new D();
	}
	
	static void DynamicWeirdness()
	{
		dynamic a = GetA();
		var c = GetC();
		a.Test = c;
	}
	
