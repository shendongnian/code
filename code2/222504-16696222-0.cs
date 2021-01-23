    public class MyFileDataReader : IDataReader
    {
        protected StreamReader Stream { get; set; }
        protected object[] Values;
        protected bool Eof { get; set; }
        protected string CurrentRecord { get; set; }
        protected int CurrentIndex { get; set; }
        public MyFileDataReader(string fileName)
        {
            Stream = new StreamReader(fileName);
            Values = new object[this.FieldCount];
        }  
