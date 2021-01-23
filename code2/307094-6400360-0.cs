    public static void RemoveUnsetObjects(object currentObject)
    {
    	var type = currentObject.GetType();
    	if (currentObject is IEnumerable)
    	{
    		IEnumerable list = (currentObject as IEnumerable);
   			foreach (object o in list)
   			{
   				RemoveUnsetObjects(o);
   			}
   		}
   		else
   		{
   			foreach (var p in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
   			{
   				var propertyValue = p.GetValue(currentObject, null);
   				if (propertyValue == null)
   					continue;
       					var setPropInfo = p.PropertyType.GetProperty("Set", typeof(bool));
   				if (setPropInfo != null)
   				{
   					var isSet = (bool)setPropInfo.GetValue(propertyValue, null);
   					if (!isSet)
   					{
   						p.SetValue(currentObject, null, null);
   					}
   				}
   				else
   				{
   					RemoveUnsetObjects(propertyValue);
   				}
   			}
   		}
   	}
