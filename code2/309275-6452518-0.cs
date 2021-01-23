    public void MyMethod(param object[] objs)
    {
        String[] strings = objs.Select(o=>o.ToString()).ToArray();
        // work with strings here
    }
