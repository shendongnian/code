    static int Inserts(string sqlInsertString, List<MyType> values)
    {
        using(var connection= 
               new SqlConnection( ConnectionStringHelper.GetConnectionString() ))
        {
            return connection.Execute(sqlInsertString, values);
        }
    }
    public class MyType
    {
        public int Field1 {get;set;}
        public string Field2 {get;set;}
        public string Etc__ {get;set;}
    }
