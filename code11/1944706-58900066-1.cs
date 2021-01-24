c#
//This beautiful function By @RezaAghaei
private IEnumerable<Control> GetAllControls(Control control)
{
    var controls = control.Controls.Cast<Control>();
    return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
}
private void button1_Click(object sender, EventArgs e)
{
    errorProvider1.Clear();
    foreach (Control c in GetAllControls(this))
    {
        if (c is TextBox && string.IsNullOrEmpty(c.Text))
            errorProvider1.SetError(c, "Error");
    }
}
Or, Linq way:
c#
errorProvider1.Clear();
GetAllControls(this).Where(c => c is TextBox && string.IsNullOrEmpty(c.Text))
    .ToList()
    .ForEach(c => errorProvider1.SetError(c, "Error"));
Good luck.
