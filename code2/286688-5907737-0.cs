    // Type t = Type.GetType(obj.ToString());
    Type t = obj.GetType(); // You might be able to replace the above line with this, simpler verison.
    PropertyInfo p = t.GetProperty("Test");
    object kk =  p.GetValue(obj, null);
    int Sum = (kk as List<int>).Sum();
