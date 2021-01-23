    public IEnumerable<object> Try_Filter(IEnumerable<object> collection,
     string property_name, string value)
    	{
    		var objTypeDictionary = new Dictionary<Type, PropertyInfo>();
    		var predicateFunc = new Func<Object, String, String, bool>((obj, propName, propValue) => {
    			var objType = obj.GetType();
    			PropertyInfo property = null;
    			if(!objTypeDictionary.ContainsKey(objType))
    			{			
    				property = objType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(prop => prop.Name == propName);
    				objTypeDictionary[objType] = property;
    			} else {
    				property = objTypeDictionary[objType];
    			}
    			if(property.GetValue(obj, null).ToString() == propValue)
    				return true;
    				
    			return false;
    		});
    		return collection.Where(obj => predicateFunc(obj, property_name, value));
    	}
