    public sealed class DataStreamManager
    {
    
      var dataStreamsMap = new Dictionary<Type, IDataStream>
        {
            { typeof(int), new DataStream<int>() }
        }
    
      public IDataStream Get<T>()
      {
        IDataStream dataStream = null;
        Type key = typeof(T);
        if (dataStreamsMap.Contains(key))
        {
           dataStream = dataStreamsMap[key];
        }
        
        return dataStream;
      }
    }
