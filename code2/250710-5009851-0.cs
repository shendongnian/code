	public class IsDirtyDecorator<T>
	{
		public bool IsDirty { get; private set; }
		private T _myValue { get; set; }
		public T MyValue
		{
			get { return _myValue; }
			set { _myValue = value; IsDirty = true; }
		}
	}
	public class MyClass
	{
		private IsDirtyDecorator<int> MyInt { get; set; }
	}
