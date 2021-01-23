	static void Test()
	{
		Derived1.AbstractStaticProp = "I am Derived1";
		Derived2.AbstractStaticProp = "I am Derived2";
		Debug.Print(Derived1.AbstractStaticProp);	// --> I am Derived1
		Debug.Print(Derived2.AbstractStaticProp);	// --> I am Derived2
	}
