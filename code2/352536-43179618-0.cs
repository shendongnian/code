    private void langItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        //I store the language codes in the Tag field of list items
        var itemClicked = e.ClickedItem;
        string culture = itemClicked.Tag.ToString().ToLower();
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        ApplyResourceToControl(
        this,
        new ComponentResourceManager(typeof(GUI)),
        new CultureInfo(culture));           
    }
    private void ApplyResourceToControl(
       Control control,
       ComponentResourceManager cmp,
       CultureInfo cultureInfo)
    {
        foreach (Control child in control.Controls)
        {
            //Store current position and size of the control
            var childSize = child.Size;
            var childLoc = child.Location;
            //Apply CultureInfo to child control
            ApplyResourceToControl(child, cmp, cultureInfo);
            //Restore position and size
            child.Location = childLoc;
            child.Size = childSize;
        }
        //Do the same with the parent control
        var parentSize = control.Size;
        var parentLoc = control.Location;
        cmp.ApplyResources(control, control.Name, cultureInfo);
        control.Location = parentLoc;
        control.Size = parentSize;
    }
