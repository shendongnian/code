    public class ObjectWalkerEntity
    {
       public object Value { get; set; }
       public PropertyInfo PropertyInfo { get; set; }
    }
    public static class ObjectWalker
    {
       public static List<ObjectWalkerEntity> Walk(object o)
       {
          return ProcessObject(o).ToList();
       }
       private static IEnumerable<ObjectWalkerEntity> ProcessObject(object o)
       {
          if (o == null)
          {
             // nothing here, just return an empty enumerable object
             return new ObjectWalkerEntity[0];
          }
          // create the list to hold values found in this object
          var objectList = new List<ObjectWalkerEntity>();
          Type t = o.GetType();
          foreach (PropertyInfo pi in t.GetProperties())
          {
             if (IsGeneric(pi.PropertyType))
             {
                // Add generic object
                var obj = new ObjectWalkerEntity();
                obj.PropertyInfo = pi;
                obj.Value = pi.GetValue(o, null);
                objectList.Add(obj);
             }
             else
             {
                // not generic, get the property value and make the recursive call
                object value = pi.GetValue(o, null);
                // all values returned from the recursive call get 
                // rolled up into the list created in this call.
                objectList.AddRange(ProcessObject(value));
             }
          } 
          return objectList.AsReadOnly();
       }
       private static bool IsGeneric(Type type)
       {
          return
              IsSubclassOfRawGeneric(type, typeof(bool)) ||
              IsSubclassOfRawGeneric(type, typeof(string)) ||
              IsSubclassOfRawGeneric(type, typeof(int)) ||
              IsSubclassOfRawGeneric(type, typeof(UInt16)) ||
              IsSubclassOfRawGeneric(type, typeof(UInt32)) ||
              IsSubclassOfRawGeneric(type, typeof(UInt64)) ||
              IsSubclassOfRawGeneric(type, typeof(DateTime));
       }
       private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
       {
          while (toCheck != typeof(object))
          {
             var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
             if (generic == cur)
             {
                return true;
             }
             toCheck = toCheck.BaseType;
          }
          return false;
       }
    }
