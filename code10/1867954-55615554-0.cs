    public class Helper
        {
            public static TValue GetOwnerAttributeValue<TValue>(MethodBase method, Func<OwnerAttribute, TValue> valueSelector) 
            {
               return method.GetCustomAttributes(typeof(OwnerAttribute), true).FirstOrDefault() is OwnerAttribute attr ? valueSelector(attr) : default(TValue);
            }
            
        }
