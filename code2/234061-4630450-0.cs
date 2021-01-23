    public static IEnumerable<Control> GetControlsOfType<T>(Control root)
        where T : Control
    {
        if (root is T)
            yield return root;
        var container = root as ContainerControl;
        if (container != null)
            foreach (Control c in container.Controls)
                foreach (var i in GetControlsOfType<T>(c))
                    yield return i;
    }
