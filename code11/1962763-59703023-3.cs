    public static void Main()
	{
		var persons = new Dictionary<string, Person>();
		persons.Add("Phong", new Person { Id = 1, Name = "Phong"});
		persons.Add("Nguyen", new Person { Id = 1, Name = "Nguyen"});
		
		var result = persons["Phong"];
			Console.WriteLine("ID: " + result.Id + " Name: " + result.Name);
            // Output: ID: 1 Name: Phong
	}
	
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
