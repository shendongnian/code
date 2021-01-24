C#
interface IDatabase<T> {
    T BeginTransaction(string connectionString);
}
class MsSql: IDatabase<SqlTransaction> {
    public SqlTransaction BeginTransaction(string connectionString) 
    { 
        tran_con = new SqlConnection(connectionString); 
        tran_con.Open(); 
        SqlTransaction transaction = tran_con.BeginTransaction(); 
        return transaction; 
    }
}
On the other hand, this is what implementing the genric method would look like:
C#
public T BeginTransaction<T>(string connectionString) { 
    // Code that generates any type T based on the connectionString
}
