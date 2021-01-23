    private IEnumerable<T> FindControls<T>(Control parent) where T : Control
    {
        foreach (Control control in parent.Controls)
        {
            if (control is T)
                yield return (T)control;
            foreach (T item in FindControls<T>(control))
                yield return item;
        }
    }
