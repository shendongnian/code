    public class BusinessBaseCollection
    {
    	protected EFBaseCollection _efObject = null;
    
    	public BusinessBaseCollection(EFBaseCollection efObject)
    	{
    		_efObject = efObject;
    	}
    
    	public Add(BusinessBase obj)
    	{
    		_efObject.Add(obj);
    	}
    
    	//Add other CRUD stuff here
    }
