	public class IsDirtyDecorator<T>
	{
		public bool IsDirty { get; private set; }
		private T _myValue { get; set; }
		public T Value
		{
			get { return _myValue; }
			set { _myValue = value; IsDirty = true; }
		}
	}
	public class MyClass
	{
		private IsDirtyDecorator<int> MyInt = new IsDirtyDecorator<int>();
		public MyClass()
		{
			MyInt.Value = 123;
			Console.WriteLine(MyInt.IsDirty);
		}
	}
