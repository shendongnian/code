    public static object AutoInvoke(
        this ISynchronizedInvoke self,
        Delegate del,
        params object[] parameters)
    {
        if (self == null)
            throw new ArgumentNullException("self");
        if (del == null)
            throw new ArgumentNullException("del");
        if (self.InvokeRequired)
            return self.Invoke(del, parameters);
        else
            return del.DynamicInvoke(parameters);
    }
