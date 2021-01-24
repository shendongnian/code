    public interface ISource
    {
        DataTable Table { get; }
    } 
    public class MySource : ISource
    {
        private DataTable table;
        public DataTable Table
        {
            get
            {
                if (table == null)
                {
                    table = new System.Data.DataTable();
                    table.Locale.DateTimeFormat.ShortDatePattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    table.Locale.DateTimeFormat.LongDatePattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern;
                }
                return table;
            }
            private set
            {
                this.table = value;
            }
        } 
    }
