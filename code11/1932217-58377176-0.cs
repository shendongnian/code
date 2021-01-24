	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	public class MyStudents
	{
		 private string student;
		 private int age;
		 public string Student
		 {
			 get { return student; }
			 set { student = value; }
		 }
		 public int Age
		 {
			 get { return age; }
			 set { age = value; }
		 }
	}
---
	public class Program
	{
		public static void Main()
		{
            // some testdata...
			var students = new List<MyStudents>
			{
				new MyStudents { Student = "John", Age = 17 },
				new MyStudents { Student = "Mary", Age = 18 },
				new MyStudents { Student = "John", Age = 17 },
				new MyStudents { Student = "Hank", Age = 20 },
			};
			
			var newList = students
               // The whole idea is, group the list by creating a key.
               .GroupBy(o => new {o.Student, o.Age})
               // you don't want to select the key, because it's an anonymous class
               // So select the first item which was added to the group.
               .Select(o => o.First())
               // create a new list.
               .ToList();
            // present them			
			foreach(var s in newList)
				Console.WriteLine("Student: "+s.Student+", Age: "+s.Age);
		}
	}}
