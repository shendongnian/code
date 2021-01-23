    public void GetControlsCollection(Control root,ref List<Control> AllControls,  Func<Control,Control> filter)
    {
        foreach (Control child in root.Controls)
        {
            var childFiltered = filter(child);
            if (childFiltered != null) AllControls.Add(child);
            if (child.HasControls()) GetControlsCollection(child, ref AllControls, filter);
        }
    }
