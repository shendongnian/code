    public static string ObjectToString(this object theObject)
    {
         if(!string.IsNullOrEmpty(theObject))
            return theObject.ToString();
         return string.Empty;
    }
    public static int ObjectToInt(this object theObject)
    {
         int result = 0;
         if(!string.IsNullOrEmpty(theObject) && int.TryParse(theObject, out result))
         {
            return result;
         }
         return -1;
    }
