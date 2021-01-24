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
