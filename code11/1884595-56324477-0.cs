	public interface IPrintable
	{
		string Name { get; }
		string Description { get; }
	}
    public class Module : IPrintable { ... }
    public class Student : IPrintable { ... }
