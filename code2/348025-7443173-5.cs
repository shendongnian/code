    public static class OracleObjectExtensions
    {
        public static UInt32 GetUInt32Value(this OracleObject oracleObject, string fieldName)
        {
            UInt32 returnValue = default(UInt32);
    
            if (oracleObject[fieldName] != null)
            {
                string rawValue = oracleObject[fieldName].ToString();
                UInt32.TryParse(rawValue, out returnValue);                
            }
    
            return returnValue;
        }
    
        public static UInt16 GetUInt16Value(this OracleObject oracleObject, string fieldName)
        {
            UInt16 returnValue = default(UInt16);
    
            if (oracleObject[fieldName] != null)
            {
                string rawValue = oracleObject[fieldName].ToString();
                UInt16.TryParse(rawValue, out returnValue);
            }
    
            return returnValue;
        }
    }
