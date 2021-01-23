    private void GetControls<T>(Control ctrl, List<T> result)
    {
        foreach (Control con in ctrl.Controls.OfType<Control>().Where(c => c.Controls.Count > 0))
            GetControls<T>(con, result);
        foreach (T control in ctrl.Controls.OfType<T>())
            result.Add(control);
    }
