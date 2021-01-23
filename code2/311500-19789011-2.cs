	using System;
	using System.Data.Entity;
	namespace ConsoleApplication1
	{
		class MyDbContext : DbContext
		{
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);
				modelBuilder.Properties().Configure(c =>
				{
					var name = c.ClrPropertyInfo.Name;
					var newName = char.ToLower(name[0]) + name.Substring(1);
					c.HasColumnName(newName);
				});
			}
			public MyDbCondenxt(string cs) : base(cs)
			{
				
			}
			public DbSet<MyModel> MyModels { get; set; }
		}
		class Program
		{
			static void Main(string[] args)
			{
				var context = new MyDbContext ("DefaultConnection");
				context.MyModels.Add(new MyModel{SomeText = "hello"});
				context.SaveChanges();
				Console.ReadLine();
			}
		}
		class MyModel
		{
			public int Id { get; set; }
			public string SomeText { get; set; }
		}
	}
