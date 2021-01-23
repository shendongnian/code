    public interface ICouchDbObject
    {
        string TableName {get;}
    }
    public class CouchDbUtil
    {
        public void SomeCouchDbSpecificMethod(ICouchDbObject couchDbObject)
        {
            var tableName = couchDbObject.TableName;
            // Do something with the table name.
        }
    }
    
    public class CouchDbCashRegister : CashRegister, ICouchDbObject
    {
        string ICouchDbObject.TableName {get{return "CashRegisters";}}
    }
