c#
public TodoItemDatabase(string dbPath)
{
    CreateDb(dbPath);
}
c#
public async void CreateDb(string dbPath)
{
    database = new SQLiteAsyncConnection(dbPath);
    // wait until first query completed
    await database.CreateTableAsync<OneTable>();
    // then execute second create query
    await database.CreateTableAsync<OtherTable>();
}
