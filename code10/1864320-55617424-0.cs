public class TableSchema
{
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }
    public int Column1 { get; set; } = 0;
    public int Column2 { get; set; } = 0;
}
BaseRepository class - it connects to database and return handler:
public abstract class BaseRepository
{
    private readonly string _databasePath;
    protected BaseRepository(string databasePath)
    {
        _databasePath = databasePath;
    }
    protected SQLite.SQLiteConnection ConnectDatabase()
    {
        SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_sqlite3());
        SQLitePCL.raw.FreezeProvider();
        return new SQLite.SQLiteConnection(_databasePath);
    }
}
repository class (contains wrappers for common used queries):
public class Repository : BaseRepository
{
    public Repository(string databasePath) : base(databasePath)
    {
    }
    public List<TableSchema> GetAll()
    {
        using (SQLite.SQLiteConnection connection = ConnectDatabase())
        {
            return connection.Table<TableSchema>().ToList();
        }
    }
    public List<TableSchema> Query(string query)
    {
        using (SQLite.SQLiteConnection sqlConnection = ConnectDatabase())
        {
            try
            {
                SQLite.SQLiteCommand queryCommand = sqlConnection.CreateCommand(query);
                List<TableSchema> results = queryCommand.ExecuteQuery<TableSchema>();
                return results;
            }
            catch (System.Exception e)
            {
                global::Tizen.Log.Error("TEST_TAG", e.Message);
                return new List<TableSchema>();
            }
        }
    }
}
and
class Sample
{
    Repository _mapRepository;
    public Sample()
    {
        _mapRepository = new Repository(App.Current.DirectoryInfo.Data + "db.sqlite3");
         List<Table> allRecords = _mapRepository.GetAll();
    }
}
