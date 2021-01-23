	public class Foo
	{
		public void Bar(string mode)
		{
			if (string.IsNullOrEmpty(mode)) throw new InvalidOperationException(Resources.InvalidModeSpecified);
		}
		public void Bar(int port)
		{
			if (port < 0 || port > Int16.MaxValue) throw new ArgumentOutOfRangeException("port");
		}
	}
	[TestClass]
	class ExampleClass
	{
		[TestMethod]
		[ExpectedExceptionWithMessage(typeof(InvalidOperationException), typeof(Samples.Resources), "InvalidModeSpecified")]
		public void Raise_Exception_With_Message_Resource()
		{
			new Foo().Bar(null);
		}
		[TestMethod]
		[ExpectedExceptionWithMessage(typeof(ArgumentOutOfRangeException), "port", true)]
		public void Raise_Exeception_Containing_String()
		{
			new Foo().Bar(-123);
		}
	}
