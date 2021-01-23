    public interface IBaseObject
    {
        int ObjectId {get;}
    }
    
    public class CashRegister : IBaseObject
    {
        int IBaseObject.ObjectId { get {return CashRegisterId;} }
        
        public int CashRegisterId {get;set;}
    }
    
    public class BaseObjectUtil
    {
        public void SomeGenericBaseObjectMethod(IBaseObject baseObject)
        {
            var objectId = baseObject.ObjectId;
            // Do something with the object ID.
        }
    }
    
    public class SomeUtility
    {
        private BaseObjectUtil _baseObjectUtil;
        public SomeUtility(BaseObjectUtil baseObjectUtil)
        {
            _baseObjectUtil = baseObjectUtil;
        }
        
        public void DoSomethingImportant(CashRegister register)
        {
            _baseObjectUtil.SomeGenericBaseObjectMethod(register);
        }
    }
