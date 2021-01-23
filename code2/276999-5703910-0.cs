	[ComVisible(true)]
	public class Foo
	{
		public void Bar(object o)
		{
			var dateTime = (DateTime)o.GetType().InvokeMember("getVarDate", BindingFlags.InvokeMethod, null, o, null);
			Console.WriteLine(dateTime);
		}
	}
