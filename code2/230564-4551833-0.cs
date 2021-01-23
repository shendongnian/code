    public class TableTransporter
    {
        private static int _indexer;
    
        private CustomQueue tableQueue = new CustomQueue();
        private Func<DataTable, String> RunPostProcess;
        private string filename;
    
        public TableTransporter()
        {
            RunPostProcess = new Func<DataTable, String>(SerializeTable);
            tableQueue.TableQueued += new EventHandler<TableQueuedEventArgs>(tableQueue_TableQueued);
        }
    
        void tableQueue_TableQueued(object sender, TableQueuedEventArgs e)
        {
            //  do something with table
            //  I can't figure out is how to pass custom object in 3rd parameter
            RunPostProcess.BeginInvoke(e.Table,new AsyncCallback(PostComplete), filename);
        }
    
        public void ExtractData()
        {
            // perform data extraction
            tableQueue.Enqueue(MakeTable());
            Console.WriteLine("Table count [{0}]", tableQueue.Count);
        }
    
        private DataTable MakeTable()
        { return new DataTable(String.Format("Table{0}", _indexer++)); }
    
        private string SerializeTable(DataTable Table)
        {
            string file = Table.TableName + ".xml";
    
            DataSet dataSet = new DataSet(Table.TableName);
    
            dataSet.Tables.Add(Table);
    
            Console.WriteLine("[{0}]Writing {1}", Thread.CurrentThread.ManagedThreadId, file);
            string xmlstream = String.Empty;
    
            using (MemoryStream memstream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                XmlTextWriter xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);
    
                xmlSerializer.Serialize(xmlWriter, dataSet);
                xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
    
                using (var fileStream = new FileStream(file, FileMode.Create))
                    fileStream.Write(StringToUTF8ByteArray(xmlstream), 0, xmlstream.Length + 2);
            }
            filename = file;
    
            return file;
        }
    
        private void PostComplete(IAsyncResult iasResult)
        {
            string file = (string)iasResult.AsyncState;
            Console.WriteLine("[{0}]Completed: {1}", Thread.CurrentThread.ManagedThreadId, file);
    
            RunPostProcess.EndInvoke(iasResult);
        }
    
        public static String UTF8ByteArrayToString(Byte[] ArrBytes)
        { return new UTF8Encoding().GetString(ArrBytes); }
    
        public static Byte[] StringToUTF8ByteArray(String XmlString)
        { return new UTF8Encoding().GetBytes(XmlString); }
    }
    
    public sealed class CustomQueue : ConcurrentQueue<DataTable>
    {
        public event EventHandler<TableQueuedEventArgs> TableQueued;
    
        public CustomQueue()
        { }
        public CustomQueue(IEnumerable<DataTable> TableCollection)
            : base(TableCollection)
        { }
    
        new public void Enqueue (DataTable Table)
        {
            base.Enqueue(Table);
            OnTableQueued(new TableQueuedEventArgs(Table));
        }
    
        public void OnTableQueued(TableQueuedEventArgs table)
        {
            EventHandler<TableQueuedEventArgs> handler = TableQueued;
    
            if (handler != null)
            {
                handler(this, table);
            }
        }
    }
    
    public class TableQueuedEventArgs : EventArgs
    {
        #region Fields
        #endregion
    
        #region Init
        public TableQueuedEventArgs(DataTable Table)
        {this.Table = Table;}
        #endregion
    
        #region Functions
        #endregion
    
        #region Properties
        public DataTable Table
        {get;set;}
        #endregion
    }
