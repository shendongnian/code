	public class ClassUnderTest
	{
		public virtual void MethodToTest()
		{
			Debug.WriteLine("In MethodToTest");
			AnotherMethod();
		}
		public virtual void AnotherMethod()
		{
			Debug.WriteLine("In AnotherMethod");
		}
	}
