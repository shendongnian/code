    public bool HasMethod(object objectToCheck, string methodName)
    {
         var type = objectToCheck.GetType();
         return type.GetMethod(methodName) != null;
    }
 
