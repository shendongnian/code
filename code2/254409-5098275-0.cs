    static void ResizeArray(ref object array, int n)
    {
        var type = array.GetType();
        var elemType = type.GetElementType();
        var resizeMethod = typeof(Array).GetMethod("Resize", BindingFlags.Static | BindingFlags.Public);
        var properResizeMethod = resizeMethod.MakeGenericMethod(elemType);
        var parameters = new object[] { array, n };
        properResizeMethod.Invoke(null, parameters);
        array = parameters[0];
    }
