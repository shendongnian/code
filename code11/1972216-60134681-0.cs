	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class MyType
	{
	   public string Name { get; set; }	
	}
	public class Program
	{
		public static void Main()
		{
			var tableName = "customers";
			var cols = new List<MyType>
			{
				new MyType { Name = "surname"},
				new MyType { Name = "firstname"},
				new MyType { Name = "dateOfBirth"}
			};
			var InsertStatement = $"Insert into { tableName } ( {String.Join(", ", cols.Select(col => col.Name))} )";
			Console.WriteLine(InsertStatement);
		}
	}
