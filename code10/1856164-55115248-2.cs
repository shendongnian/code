    [Serializable]
    public class MyDataTable : DataTable
    {
        void SetCulture()
        {
            this.Locale.DateTimeFormat.ShortDatePattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            this.Locale.DateTimeFormat.LongDatePattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern;
        }
        public MyDataTable()
            : base()
        {
            SetCulture();
        }
    
        public MyDataTable(string tableName)
            : base(tableName)
        {
            SetCulture();
        }
    
        public MyDataTable(string tableName, string tableNamespace)
            : base(tableName, tableNamespace)
        {
            SetCulture();
        } 
    
        /// <summary>
        /// Needs using System.Runtime.Serialization;
        /// </summary>
        public MyDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            SetCulture();
        } 
    }
