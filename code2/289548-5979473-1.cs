    public static void InvokeOnToolStrip(ToolStripStatusLabel label,    
        Action<ToolStripStatusLabel> action)
    {
        ToolStrip parent = label.GetCurrentParent();
        if (parent.InvokeRequired)
        {
            parent.Invoke((Delegate) action, new object[] { label });
        }
        else
        {
            action(label);
        }
    }
