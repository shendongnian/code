	Console.WriteLine("testing base class");
	BaseClass baseClass = new BaseClass();
	baseClass.Method();
	baseClass.OverrideableMethod();
	Console.WriteLine("\n\ntesting specialized class");
	SpecializedClass specializedClass = new SpecializedClass();
	specializedClass.Method();
	specializedClass.OverrideableMethod();
	Console.WriteLine("\n\nuse specialized class as base class");
	BaseClass containsSpecializedClass = specializedClass;
	containsSpecializedClass.Method();
	containsSpecializedClass.OverrideableMethod();
