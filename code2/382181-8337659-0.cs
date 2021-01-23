    [DataContract]      
    public class TableData<T>      
    {          
        List<T> data;          
        string tableName = "";            
        
        [DataMember]          
        public string TableName          
        {
            get { return tableName; }              
            set { tableName = value; }          
        }            
        [DataMember]          
        public List<T> Data          
        {              
            get { return data; }              
            set { data = value; }          
        }  
    }
