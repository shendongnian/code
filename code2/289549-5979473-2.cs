    public static void InvokeOnToolStripItem<T>(this T item, Action<T> action)
        where T : ToolStripItem
    {
        ToolStrip parent = item.GetCurrentParent();
        if (parent.InvokeRequired)
        {
            parent.Invoke((Delegate)action, new object[] { item });
        }
        else
        {
            action(item);
        }
    }
