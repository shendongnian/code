    public static void MyMethod(this MyObject t, param object[] objs)
    {
        String[] strings = objs.Select(o=>o.ToString()).ToArray();
        t.MyMethod(strings);
    }
