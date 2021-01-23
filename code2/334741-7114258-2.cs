	public class Animal
	{
	}
	public class Dog : Animal
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				Console.WriteLine("Name is now " + _name);
			}
		}
	}
	public class Duck : Animal
	{
		public void Fly()
		{
			Console.WriteLine("Flying");
		}
	}
