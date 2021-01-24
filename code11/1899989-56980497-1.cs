	void Main()
	{
		var result = Wrapper(DoSomething);
	}
	
	private void DoSomething()
	{
		Console.WriteLine("Test.");
	}
	
	T Wrapper<T>(Func<T> func)
	{
		Console.WriteLine("Wrap start");
		var result = func();
		Console.WriteLine("Wrap end");
		return result;
	}
	
	Unit Wrapper(Action action)
	{
		return Wrapper(() => { action(); return Unit.Default; });
	}
	
	/// <summary>
	/// Represents a type with a single value. This type is often used to denote the successful completion of a void-returning method (C#) or a Sub procedure (Visual Basic).
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Unit : IEquatable<Unit>
	{
		public static Unit Default => default(Unit);
		public bool Equals(Unit other) => true;
		public override bool Equals(object obj) => obj is Unit;
		public override int GetHashCode() => 0;
		public override string ToString() => "()";
		public static bool operator ==(Unit first, Unit second) => true;
		public static bool operator !=(Unit first, Unit second) => false;
	}
