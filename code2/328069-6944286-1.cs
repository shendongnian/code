    var someState = GetSomeState();
    Parallel.ForEach(MyIEnumerableSource, 
        () => new DataTable(),
        (record, loopState, localDataTable) =>
           OtherClass.Process(record, loopState, LocalDataTable, someState),
        (localDataTable) => { ... }
    );
    static class OtherClass
    {
        public static DataTable Process(MyRecordType record, ParallelLoopState loopState, DataTable localDataTable, someStateType someState)
        {
            localDataTable.Rows.Add(someState.Value, record);
            return localDataTable
        }
    }
