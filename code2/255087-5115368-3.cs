    public class PODataContext : DataContext
      {
  
       public Table<MyTable> myTables;
      
        public PODataContext(string connection): base(connection)
    
        {
    
        }
    
    }
