	public class IsDirtyDecorator<T>
	{
		public bool IsDirty { get; private set; }
		private T _myValue;
		public T Value
		{
			get { return _myValue; }
			set { _myValue = value; IsDirty = true; }
		}
	}
	public class MyClass
	{
		private IsDirtyDecorator<int> MyInt = new IsDirtyDecorator<int>();
		private IsDirtyDecorator<string> MyString = new IsDirtyDecorator<string>();
		public MyClass()
		{
			MyInt.Value = 123;
			MyString.Value = "Hello";
			Console.WriteLine(MyInt.Value);
			Console.WriteLine(MyInt.IsDirty);
			Console.WriteLine(MyString.Value);
			Console.WriteLine(MyString.IsDirty);
		}
	}
