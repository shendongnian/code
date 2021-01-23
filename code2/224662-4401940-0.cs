    public class DateFormattingDataReader : IDataReader
    {
        private readonly IDataReader inner;
        
        public DateFormattingDataReader(IDataReader inner)
        {
            this.inner = inner;
        }
        
        public string GetString(int index)
        {
            string s = this.inner.GetString(index);
            if(index == problematicColumnIndex)
            {
                //try to parse string and then format it for the library
            }
            else return s;
        }
    }
