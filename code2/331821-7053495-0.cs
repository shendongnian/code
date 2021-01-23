	abstract class MyBase
	{
		public object CustomObject { get; private set; }
	
		public MyBase()
		{
			this.CustomObject = this.CreateCustomObject();
		}
		
		protected abstract object CreateCustomObject();
	}
	
	class MyBaseList : MyBase
	{
		protected override object CreateCustomObject()
		{
			return new List<int>();
		}
	}
	
	class MyBaseDict : MyBase
	{
		protected override object CreateCustomObject()
		{
			return new Dictionary<int, int>();
		}
	}
