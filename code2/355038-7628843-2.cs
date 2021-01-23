    public static IEnumerable<Control> GetControlHierarchy(Control parent, string controlID)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl.ID == controlID)
                yield return ctrl;
            else
            {
                var result = GetControlHierarchy(ctrl, controlID);
                if (result != null)
                    yield return ctrl;
            }
            yield return null;
        }
    }
