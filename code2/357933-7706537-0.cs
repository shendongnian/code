    public static void Clear(Control ctrl)
    {
        foreach(Control c in ctrl.Controls) c.Dispose();
        ctrl.Controls.Clear();
    }
