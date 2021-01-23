    bool IsEnumerable(object obj)
    {
        if (obj is IEnumerable)
            return true;
        var info = obj.GetType().GetMethod("GetEnumerator");
        if (info != null)
        {
            if (info.ReturnType != null)
            {
                var moveNextMethod = info.ReturnType.GetMethod("MoveNext");
                if (moveNextMethod != null && moveNextMethod.ReturnType == typeof(bool))
                {
                    var currentProperty = info.ReturnType.GetProperty("Current");
                    if (currentProperty != null)
                        return true;
                }
            }
        }
        return false;
    }
