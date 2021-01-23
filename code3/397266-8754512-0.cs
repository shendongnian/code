    public void ModifyControl<T>(Control root, Action<T> action) where T : Control
    {
        if (root is T)
            action((T)root);
        // Call ModifyControl on all child controls
        foreach (Control control in root.Controls)
            ModifyControl<T>(control, action);
    }
