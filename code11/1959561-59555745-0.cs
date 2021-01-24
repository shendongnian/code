c#
checkBox1.Tag = "Setting1";
checkBox2.Tag = "Setting2";
checkBox3.Tag = "Setting3";
Create a method to load your settings:
c#
private void LoadSettings()
{
    foreach (Control c in ParentContainer.Controls)
    {
        if (c is CheckBox && !string.IsNullOrEmpty(c.Tag?.ToString()))
            ((CheckBox)c).Checked = Properties.Settings.Default[c.Tag.ToString()] as bool? ?? false;
        //if (c is anotherType) { Do something else. }
    }
}
Another one to save them:
c#
private void SaveSettings()
{
    foreach (Control c in ParentContainer.Controls)
    {
        if (c is CheckBox && !string.IsNullOrEmpty(c.Tag?.ToString()))
            Properties.Settings.Default[c.Tag.ToString()] = ((CheckBox)c).Checked;
    }
    Properties.Settings.Default.Save();
    Properties.Settings.Default.Upgrade();
}
If the controls are hosted in different containers, then you need to use a recursive function to get them:
c#
private IEnumerable<Control> GetAllControls(Control container)
{
    var controls = container.Controls.Cast<Control>();
    return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
}
And change the two methods as follows:
c#
private void LoadSettings()
{
    //You can pass the container that directly or indirectly hosts
    //the target controls instead of (this).
    foreach (Control c in GetAllControls(this))
    {
        if (c is CheckBox && !string.IsNullOrEmpty(c.Tag?.ToString()))
            ((CheckBox)c).Checked = Properties.Settings.Default[c.Tag.ToString()] as bool? ?? false;
    }
}        
private void SaveSettings()
{
    foreach (Control c in GetAllControls(this))
    {
        if (c is CheckBox && !string.IsNullOrEmpty(c.Tag?.ToString()))
            Properties.Settings.Default[c.Tag.ToString()] = ((CheckBox)c).Checked;
    }
    Properties.Settings.Default.Save();
    Properties.Settings.Default.Upgrade();
}
