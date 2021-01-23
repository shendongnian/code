    public static void MyMethod(param object[] objs)
    {
        String[] strings = objs.Select(o=>o.ToString()).ToArray();
        MyStaticObject.MyMethod(strings);
    }
