     public class SomeValueType
    {
        Dictionary<string, ValueType[]> tempDict = new Dictionary<string, ValueType[]>();
     
        public SomeValueType(ValueType[] source,string keyName)
        {
           
                 tempDict[keyName]= source;
            
        }
        
    }
