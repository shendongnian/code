    [ServiceContract]
    public interface ITableReader
    {
      [OperationContract]
      DataTable GetTable();
    }
