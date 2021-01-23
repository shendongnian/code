    public static void CallAllAndCatch(this EventHandler<T> self, object sender, T args)
        where T : EventArgs
    {
        if (self == null)
            return;
        foreach (EventHandler<T> i in self.GetInvocationList()) {
            try { i(sender, args); }
            catch { }
        }
    }
