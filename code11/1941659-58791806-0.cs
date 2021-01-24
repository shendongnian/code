	namespace Dapper
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
		class DbConnector
		{
			protected readonly Dapper.DbConnection _connection = new Dapper.DbConnection();
			public void InsertDynamicObject(object obj)
			{
				var a = typeof(Dapper.DbConnection).GetMethod("Insert");
				var b = a.MakeGenericMethod(new [] { obj.GetType() });
				b.Invoke(_connection, new[] { obj });
			}
		}
		public class Program
		{
			public static void Main()
			{
				object someObject = "Test";
				var connector = new DbConnector();
				connector.InsertDynamicObject(someObject);
			}
		}
	}
