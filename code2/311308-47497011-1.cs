    public static void InvokeIfRequiredToolstrip<T>(this T c, Action<T> action) where T : ToolStripItem
    {
        if (c.GetCurrentParent().InvokeRequired)
        {
            c.GetCurrentParent().Invoke(new Action(() => action(c)));
        }
        else
        {
            action(c);
        }
    }
