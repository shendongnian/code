    public class BLLObject 
    {
       public IDal DalInstance {get;set;}
       public BLLObject(IDal _dalInstance)
       {
          DalInstance = _dalInstance;
       }
    }
