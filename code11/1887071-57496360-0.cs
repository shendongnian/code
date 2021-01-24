    public interface IDatabase
    {
        void SaveToDatabase();
        void ReadFromDatabase();
    }
    
    public class MySQLDatabase : IDatabase
    {
       public MySQLDatabase ()
       {
          //init stuff
       }
    
       public void SaveToDatabase(){
           //MySql implementation
       }
       public void ReadFromDatabase(){
          //MySql implementation
       }
    }
    
    public class SQLLiteDatabase : IDatabase
    {
       public SQLLiteDatabase ()
       {
          //init stuff
       }
    
       public void SaveToDatabase(){
           //SQLLite implementation
       }
       public void ReadFromDatabase(){
          //SQLLite implementation
       }
    }
    
    //Application
    public class Foo {
        public IDatabase db = GetDatabase();
    
        public void SaveData(){
            db.SaveToDatabase();
        }
    
        private IDatabase GetDatabase()
        {
            if(/*some way to tell if should use MySql*/)
                return new MySQLDatabase();
            else if(/*some way to tell if should use MySql*/)
                return new SQLLiteDatabase();
    
            throw new Exception("You forgot to configure the database!");
        }
    }
