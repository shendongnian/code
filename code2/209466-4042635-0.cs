    public interface IDataCtx
    {
       void CallDB();
    }
    
    public class MyDataCtx : IDataCtx
    { 
       private SqlConnection dc;
    
       public MyDataCtx() { dc = new SqlConnection(); dc.Open(); }
    
       public void CallDB();
       {
           dc.Something();
       }
    }
