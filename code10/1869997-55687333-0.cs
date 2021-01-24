c#
public async TodoItemDatabase(string dbPath)
{
    database = new SQLiteAsyncConnection(dbPath);
    // wait until first query completed
    await database.CreateTableAsync<OneTable>();
    // then execute second create query
    await database.CreateTableAsync<OtherTable>();
}
