    class C : A
	{
		public new void F() { }
	}
	
	class D : A
	{
		public override void F() { }
	}
    // Later
	C c1 = new C();
	c1.F(); // will call C.F()
	
	A c2 = new C();
	c2.F(); // will call A.F()
	
	D d1 = new D();
	d1.F(); // will call D.F()
	
	A d2 = new D();
	d2.F(); // will call D.F()
