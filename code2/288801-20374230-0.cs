    public interface IConnectorDataReader
    {
      int ColumnCount
      {
        get;
      }
      bool readNextRecord();
      string this[int i]
      {
        get;
      }
      void reset();
    }
