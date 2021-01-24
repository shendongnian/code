	// Entity Framework Extensions
	// Doc: https://entityframework-extensions.net/context-factory
	// @nuget: Microsoft.EntityFrameworkCore
	// nuget: Z.EntityFramework.Extensions.EFCore
	// @nuget: Microsoft.EntityFrameworkCore.SqlServer
	// @nuget: Microsoft.Extensions.Logging
	using System;
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Microsoft.Extensions.Logging;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var p = new Person();
			using (var context = new EntityContext())
			{
				context.Database.EnsureCreated();
				p.Age = 29;
				context.Persons.Add(p);
				context.SaveChanges();
			}
			using (var context = new EntityContext())
			{
				Console.WriteLine("Created Person Age 29");
				FiddleHelper.WriteTable("Student", context.Persons.ToList());
			}
			using (var context = new EntityContext())
			{
				p.Age = 30;
				context.Persons.Update(p);
				context.SaveChanges();
			}
			using (var context = new EntityContext())
			{
				Console.WriteLine("Update Person Age 30");
				FiddleHelper.WriteTable("Student", context.Persons.ToList());
			}
			using (var context = new EntityContext())
			{
				p.Age = 31;
				context.Persons.Attach(p);
				context.SaveChanges();
			}
			using (var context = new EntityContext())
			{
				Console.WriteLine("Change Person to 31, THEN Attach");
				FiddleHelper.WriteTable("Student", context.Persons.ToList());
			}
			using (var context = new EntityContext())
			{
				context.Persons.Attach(p);
				p.Age = 32;
				context.SaveChanges();
			}
			using (var context = new EntityContext())
			{
				Console.WriteLine("Attach THEN Change Person to 32");
				FiddleHelper.WriteTable("Student", context.Persons.ToList());
			}
		}
		public class EntityContext : DbContext
		{
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				var connectionString = FiddleHelper.GetConnectionStringSqlServer();
				optionsBuilder.UseSqlServer(connectionString);
			}
			public DbSet<Person> Persons { get; set; }
		}
		public class Person
		{
			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.None)]
			public int Id { get; set; }
			public int Age { get; set; }
			public string Name { get; set; }
		}
	}
