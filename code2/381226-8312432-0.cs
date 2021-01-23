    public class DataRepository
    {
       private MyDataContext ctx;
       
    public DataRepository(string connection){
        ctx = new MyDataContext(connection);
    }
    //now you can use your context
    }
