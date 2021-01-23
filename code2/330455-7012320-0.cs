	public class BaseClass
	{
		// This method can be "replaced" by classes which inherit this class
		public virtual void OverrideableMethod()
		{
			System.Console.WriteLine("BaseClass.OverrideableMethod()");
		}
		// This method is called when the type is of your variable is "BaseClass"
		public void Method()
		{
			Console.WriteLine("BaseClass.Method()");
		}
	}
	public class SpecializedClass : BaseClass
	{
		// your specialized code
		// the original method from BaseClasse is not accessible anymore
		public override void OverrideableMethod()
		{
			Console.WriteLine("SpecializedClass.OverrideableMethod()");
			// call the base method if you need to
			// base.OverrideableMethod();
		}
		// this method hides the Base Classes code, but it still is accessible
		// - without the "new" keyword the compiler generates a warning
		// - try to avoid method hiding
		// - it is called when the type is of your variable is "SpecializedClass"
		public new void Method()
		{
			Console.WriteLine("SpecializedClass.Method()");
		}
	}
