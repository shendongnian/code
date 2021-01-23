    class Program
	{
		class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public byte Age { get; set; }
			public override string ToString()
			{
				return string.Format("{0}, {1} ({2})", LastName, FirstName, Age);
			}
		}
		static void Main(string[] args)
		{
			Person p1 = new Person() { FirstName = "Bill", LastName = "Johnson", Age = 34 };
			Person p2 = new Person() { FirstName = "Sally", LastName = "Jones", Age = 21 };
			Person p3 = new Person() { FirstName = "Jame", LastName = "Smith", Age = 28 };
			List<Person> people = new List<Person>(new Person[] { p1, p2, p3 });
			IEnumerable<Person> foundPeople = people.Where(p => p.GetType().GetProperty("LastName").GetValue(p,null).ToString().StartsWith("J"));
			foreach (Person person in foundPeople)
			{
				Console.WriteLine(person.ToString());
			}
			Console.ReadKey();
		}
	}
