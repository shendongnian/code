      class WcfModel: IWcfModel
      {
        private List<ConsoleData> _dataList;
    
        public List<ConsoleData> DataList
        {
          get { return _dataList; }
          set
          {
            _dataList = value;
            if ( DataArrived != null )
              DataArrived ( _dataList );
          }
        }
    
        public event Action<List<ConsoleData>> DataArrived;
      }
