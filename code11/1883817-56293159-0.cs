c#
static void Main(string[] args)
{
    try
    {
        System.Threading.Tasks.Parallel.ForEach(names, name =>
        {
            var warehouseHelper = new WarehouseHelper();
            warehouseHelper.BeginTransaction();
            for(int i = 0; i < 10; i++)
            {
                warehouseHelper.ExecuteNonQuery(CreateQuery);
                warehouseHelper.ExecuteNonQuery(string.Format(InsertQuery, name));                
            }
            using (var reader = warehouseHelper.ExecuteReader(SelectQuery))
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["name"]);
                }
            }
            warehouseHelper.CommitTranzaction();
        }
        );
    }
    catch(Exception ex)
    {
        Console.Write(ex.Message);
    }
}
