		public static IEnumerable<Person> Where(this IEnumerable<Person> collection, Func<Person, bool> condition )
		{
			Console.WriteLine("My Custom 'Where' method called");
			return System.Linq.Enumerable.Where(collection, condition);
		}
...
			var x = from t in people
					where t.Age > 18 && t.Age < 21
					select t; //Will print "My Custom 'Where' method called"
