    var someState = GetSomeState();
    Parallel.ForEach(MyIEnumerableSource, 
        () =>
        {
            return new DataTable();
        },
        (record, loopState, localDataTable)
        {
            return OtherClass.Process(record,loopState,LocalDataTable,someState);
        },
        (localDataTable) =>
        {
            using (var bulkInsert = new SqlBulkCopy(ConnectionString))
            {
                bulkInsert.DestinationTableName = "My_Table";
                bulkInsert.WriteToServer(localDataTable);
            }
            localDataTable.Dispose();
        });
    static class OtherClass
    {
        public static DataTable Process(MyRecordType record, ParallelLoopState loopState, DataTable localDataTable, someStateType someState)
        {
            localDataTable.Rows.Add(someState.Value, record);
            return localDataTable
        }
    }
