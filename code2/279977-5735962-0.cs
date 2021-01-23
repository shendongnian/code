    public sealed class DBNull 
    {
       public static readonly DBNull Value;
  
       static DBNull()
       {
          Value = new DBNull();
       }
       private DBNull() {}
    }
