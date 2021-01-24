    static int Inserts<T>(string sqlInsertString, IEnumerable<T> values)
    {
        using(var connection= 
               new SqlConnection( ConnectionStringHelper.GetConnectionString() ))
        {
            return connection.Execute(sqlInsertString, values);
        }
    }
    static int Inserts(string sqlInsertString, DataTable values)
    {
        return Inserts(sqlInsertString, values.Select();
    }
    public class MyType
    {
        public int Field1 {get;set;}
        public string Field2 {get;set;}
        public string Etc__ {get;set;}
    }
