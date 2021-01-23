    public class BLLObject 
    {
        public IDal DalInstance { get; set; }
        public BLLObject()
        {
            DalInstance = DalFactory.CreateSqlServerDal();
        }
    }
     
