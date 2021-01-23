    [DataContract]
    public class TableData
    {
        List<T> data;                    //Here what do you want in the data object? a List of strings or a List of your custom defined class types? so you declare List<string> data; or List<MyClass> data; Although I prefer you use IList instead of List.
        string tableName = "";
        [DataMember]
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        [DataMember]
        public List<T> Data          //Then here as well you use public IList<string> Data or public IList<Myclass> data and it should be fine.
        {
            get { return data; }
            set { data = value; }
        }
    }
