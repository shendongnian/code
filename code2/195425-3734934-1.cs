    public static object ConvertParameter(JsInstance parameter)
    {
    	if (parameter.Class != JsFunction.TYPEOF && parameter.Class != JsArray.TYPEOF && parameter.Class != JsObject.TYPEOF)
    	{
    		return parameter.Value;
    	}
    	else if (parameter == JsNull.Instance)
    	{
    		return null;
    	}
    	else
    	{
    		JsFunction constructor = ((JsDictionaryObject)parameter)["constructor"] as JsFunction;
    		if (constructor == null) return parameter;
    
    		switch (constructor.Name)
    		{
    			case "Date":
    				return JsDateConstructor.CreateDateTime(parameter.ToNumber());
    			case "String":
    			case "RegExp":
    			case "Number":
    				return parameter.Value;
    			case "Array":
    				object[] array = new object[((JsObject)parameter).Length];
    				foreach (KeyValuePair<string, JsInstance> key in (JsObject)parameter)
    				{
    					int index = 0;
    					if (int.TryParse(key.Key, out index))
    					{
    						array[index] = ConvertParameters(key.Value)[0];
    					}
    				}
    				return array;
    			case "Object":
    
    				if (parameter.Class == JsFunction.TYPEOF) return parameter;
    
    				Dictionary<string, object> dic = new Dictionary<string, object>();
    				foreach (KeyValuePair<string, JsInstance> key in (JsObject)parameter)
    				{
    					dic.Add(key.Key, ConvertParameter(key.Value));
    				}
    				return dic;
    			default:
    				return parameter;
    		}
    	}
    
    }
