    public static T GetAncestorOfType<T>(System.Web.UI.Control control) where T : class
    {
        var parent = control;
        while (!(parent is T))
        {
            parent = parent.Parent;
            continue;
        }
        return parent as T;
    }
