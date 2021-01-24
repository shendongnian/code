	namespace Dapper  //This is a stub for the Dapper framework that you cannot change
	{
		class DbConnection
		{
			public void Insert<T>(T obj)
			{
				Console.WriteLine("Inserting an object with type {0}", typeof(T).FullName);
			}
		}
	}
	namespace MyProgram
	{
		class DbConnector  //Here is your DbConnector class, which wraps Dapper
		{
			protected readonly Dapper.DbConnection _connection = new Dapper.DbConnection();
			public void InsertDynamicObject(object obj)
			{
				typeof(Dapper.DbConnection)
					.GetMethod("Insert")
					.MakeGenericMethod(new [] { obj.GetType() })
					.Invoke(_connection, new[] { obj });
			}
		}
		public class Program
		{
			public static void Main()
			{
				object someObject = "Test";  //This is the object that you deserialized where you don't know the type at compile time.
				var connector = new DbConnector();
				connector.InsertDynamicObject(someObject);
			}
		}
	}
