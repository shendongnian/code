	class ValueTypeReference<T> where T : struct
	{
		public  T Value { get; set; }
	}
	class Foo
	{
		private ValueTypeReference<int> _privateField = new ValueTypeReference<int>{ Value = 0 };
		public ValueTypeReference<int> GetReference()
		{
			return _privateField;
		}
		public override string ToString() 
		{
			return _privateField.Value.ToString();
		}
	}
	public class Program
	{
		public static void Main()
		{
			var foo = new Foo();
			var referenceToPrivateField = foo.GetReference();
			referenceToPrivateField.Value = 100;
			Console.WriteLine(foo);
		}
	}
