    public interface ISqlDbManager
    {
       void SaveOrder(Order o);
       void FindOrderById(int orderId);
    }
    
    public class SqlServerDbManager : ISqlDbManager
    {
        private static void RunSql(String pSql, DBParamsHelper pDBParams, String   pConnStringConfigName)
        {
           // implement as you did above
        }
    
       public void FindOrderById(int orderId)
       {
          // create SQL, call private "RunSql" method.
       }
    }
