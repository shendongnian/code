    public static bool IsNull<T>(this T myObject, string message = "") where T : UnityEngine.Object
    {
        if(!myObject)
        {
            Debug.LogError("The object is null! " + message);
            return false;
        }
    
        return true;
    }
