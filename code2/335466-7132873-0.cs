    public class DataImporter<T>
    {
        public DataImporter(string tableName, string readerName)
        {
            _tableName = tableName;
            _readerName = readerName;
        }
        /// <summary>
        /// This is the size of our bulk staging list.
        /// </summary>
        /// <remarks>
        /// Note that the SqlBulkCopy object has a batch size property, which may not be the same as this value,
        /// so records may not be going into the database in sizes of this staging value.
        /// </remarks>
        private int _bulkStagingListSize = 20000;
        private List<ManualResetEvent> _tasksWaiting = new List<ManualResetEvent>();
        private string _tableName = String.Empty;
        private string _readerName = String.Empty;
        public void QueueForImport(T record)
        {
            lock (_listLock)
            {
                _items.Add(record);
                if (_items.Count > _bulkStagingListSize)
                {
                    SaveItems(_items);
                    _items = new List<T>();
                }
            }
        }
        /// <summary>
        /// This method should be called at the end of the queueing work to ensure to clear down our list
        /// </summary>
        public void Flush()
        {
            lock (_listLock)
            {
                SaveItems(_items);
                _items = new List<T>();
                while (_tasksWaiting.Count > 64)
                {
                    Thread.Sleep(2000);
                }
                WaitHandle.WaitAll(_tasksWaiting.ToArray());
            }
        }
        private void SaveItems(List<T> items)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            _tasksWaiting.Add(evt);
            IDataReader reader = DataReaderFactory.GetReader<T>(_readerName,_items);
            Tuple<ManualResetEvent, IDataReader> stateInfo = new Tuple<ManualResetEvent, IDataReader>(evt, reader);
            ThreadPool.QueueUserWorkItem(new WaitCallback(saveData), stateInfo);
        }
        private void saveData(object info)
        {
            using (new ActivityTimer("Saving bulk data to " + _tableName))
            {
                Tuple<ManualResetEvent, IDataReader> stateInfo = info as Tuple<ManualResetEvent, IDataReader>;
                IDataReader r = stateInfo.Item2;
                try
                {
                    Database.DataImportStagingDatabase.BulkLoadData(r, _tableName);
                }
                catch (Exception ex)
                {
                    //Do something
                }
                finally
                {
                    _tasksWaiting.Remove(stateInfo.Item1);
                    stateInfo.Item1.Set();
                }
            }
        }
        private object _listLock = new object();
        private List<T> _items = new List<T>();
    }
