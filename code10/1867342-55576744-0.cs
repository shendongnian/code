    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Dynamic;
	public class Program
	{
		public static void Main()
		{
			var lstContacts = new List<Contact>{
				new Contact{Id = 1, Active = true, Name = "Chris"}, 
				new Contact{Id = 2, Active = true, Name = "Scott"}, 
				new Contact{Id = 3, Active = true, Name = "Mark"}, 
				new Contact{Id = 4, Active = false, Name = "Alan"}};
		
			string columnName = "Active";
			List<Contact> results = lstContacts.Where(String.Format("{0} == true", columnName)).ToList();
			foreach (var item in results)
			{
				Console.WriteLine(item.Id.ToString() + " - " + item.Name.ToString());
			}
		}
	}
	public class Contact
	{
		public int Id
		{
			get;
			set;
		}
		public bool Active
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
	}
