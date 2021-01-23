    public static public void FireEvent<T>(this EventHandler handler, object sender, EventArgs<T> e)
        where T : EventArgs
    {
        if (handler != null)
            handler(sender, e);
    }
