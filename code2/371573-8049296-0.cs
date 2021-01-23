	using System.Data;
	namespace ConsoleApplication7
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				IDBInteractor<DataTable> dt = new DBInteractorDT();
				IDBInteractor<JsonString> js = new DBInteractorJson();
				DataTable myDT = dt.ExecuteDSQuery("");
				JsonString myJson = js.ExecuteDSQuery("");
			}
		}
		public interface IDBInteractor<T>
		{
			T ExecuteDSQuery(string myQuery);
		}
		public class DBInteractorDT : IDBInteractor<DataTable>
		{
			#region IDBInteractor<DataTable> Members
			public DataTable ExecuteDSQuery(string myQuery)
			{
				return new DataTable();
			}
			#endregion
		}
		public class DBInteractorJson : IDBInteractor<JsonString>
		{
			#region IDBInteractor<JsonString> Members
			public JsonString ExecuteDSQuery(string myQuery)
			{
				return new JsonString();
			}
			#endregion
		}
		public class JsonString
		{
		}
	}
