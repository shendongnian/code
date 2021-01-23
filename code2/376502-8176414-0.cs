        public IEnumerable<object> Try_Filter(IEnumerable<object> collection,
     string property_name, string value)
    	{
    		var objTypeDictionary = new Dictionary<Type, PropertyInfo[]>();
    		var predicateFunc = new Func<Object, String, String, bool>((obj, propName, propValue) => {
    			var objType = obj.GetType();
    			PropertyInfo[] props = null;
    			if(!objTypeDictionary.ContainsKey(objType))
    			{			
    				props = objType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    				objTypeDictionary[objType] = props;
    			} else {
    				props = objTypeDictionary[objType];
    			}
    			var matchingProp = props.FirstOrDefault(prop => prop.Name == propName);
    			if(matchingProp.GetValue(obj, null).ToString() == propValue)
    				return true;
    				
    			return false;
    		});
    		return collection.Where(obj => predicateFunc(obj, property_name, value));
    	}
