    public static SomeObject GetTheObject(IMyObject genericObject) {
    	Type t = genericObject.GetType();
    
    	Func<SomeObject, bool> WhereClause = null;
    	IEnumerable<SomeObject> objs = null; // IEnumerable<T> is covariant, 
                          // so we can assign it both an IEnumerable<object1>
                          // and an IEnumerable<object2> (provided object1 and 2 are
                          // subclasses of SomeObject)
    	
    	switch(t.Name) {
    		case "Type1":
    			WhereClause = o => ((Object1)o).object1id == genericObject.id;		
    			objs = object1s;
    		break;
    		case "Type2":
    			WhereClause = o =>  ((Object2)o).object2id == genericObject.id;		
    			objs = object2s;
    		break;
    	}
    
    	var ob = objs
    	.Where(WhereClause)
    	.FirstOrDefault();
    	
    	return (SomeObject)ob;
    }
 
