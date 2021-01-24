	public class MyAppContext : IAbcdContext
	{
		private readonly string _databaseName = "MyApp.sqlite";
		private readonly SQLiteConnection _dbConnection;
		
		public MyAppContext()
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string dbFilePath = Path.Combine(docFolder, DatabaseName);
			_dbConnection = new SQLiteConnection(dbFilePath);
		}
		public int AddQuestion(Question question)
		{
			return _dbConnection.Insert(question);
		}
		
		...
	}
