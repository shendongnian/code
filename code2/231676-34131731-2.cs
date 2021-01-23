    public class Person {
		public string Name {get;set;}
		public int Age {get;set;}
	}
    List<Person> list = new List<Person>() { new Person() { Name = "John", Age = 22 }, new Person() { Name = "John", Age = 30 }, new Person() { Name = "Jack", Age = 30 } };
		
	var duplicateNames = list.FindDuplicates(p => p.Name);
	var duplicateAges = list.FindDuplicates(p => p.Age);
		
	foreach(var dupName in duplicateNames) {
		Console.WriteLine(dupName); // Will print out John
	}
		
	foreach(var dupAge in duplicateAges) {
		Console.WriteLine(dupAge); // Will print out 30
	}
