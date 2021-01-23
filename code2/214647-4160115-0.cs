    public static void CallAllAndCatch(this Action self)
    {
        if (self == null)
            return;
        foreach (Action i in self.GetInvocationList()) {
            try { i(); }
            catch { }
        }
    }
