    Type[] arr = new[] { typeof(X), typeof(Y), typeof(Z) };
    foreach(Type t in arr)
    {
        FieldInfo fi = t.GetField("m", BindingFlags.Static | BindingFlags.NonPublic);
        // or PropertyInfo pi = t.GetProperty(...);
        string m  = (string)fi.GetValue(null);
        // GetValue(null, null);
    }
