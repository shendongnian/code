	public void Run()
	{
		var safePod1 = SafePod.CreateForReferenceTypeResult(Calc1);
		var safePod2 = SafePod.CreateForReferenceTypeResult(Calc2);
		var safePod3 = SafePod.CreateForReferenceTypeResult(Calc3);
		User w = safePod1() ?? safePod2() ?? safePod3();
		if (w == null) throw new NoCalcsWorkedException();
		Console.Out.WriteLine($"The user object is {{{w}}}"); // The user object is {Name: Mike}
	}
	
	private static User Calc1() => throw new Exception("Intentionally thrown exception");
	private static User Calc2() => new User { Name = "Mike" };
	private static User Calc3() => new User { Name = "Alex" };
	
	class User
	{
		public string Name { get; set; }
		public override string ToString() => $"{nameof(Name)}: {Name}";
	}
