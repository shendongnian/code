	class Person
	{
		public Person(string name)
		{
			Debug.WriteLine("My name is " + name);
		}
	}
	class Employee : Person
	{
		public Employee(string name, string job)
			: base(name)
		{
			Debug.WriteLine("I " + job + " for money.");
		}
		public Employee() : this("Jeff", "write code")
		{
			Debug.WriteLine("I like cake.");
		}
	}
