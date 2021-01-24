 c#
private void action_Insert_Click(object sender, EventArgs e)
{
    //validation
    if (Controls.OfType<Control>().Any(x => !IsEmpty(x)))
    {
        MessageBox.Show("Some Values Are Empty or Not Proper... ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
    //insert statement
}
private void action_Reset_Click(object sender, EventArgs e)
{
    ClearAllText(this);
}
void ClearAllText(Control con)
{
    foreach (Control c in con.Controls) Clear(c);
}
private bool IsEmpty(Control control)
{
    if (control is TextBox txt)
        return txt.Text == string.Empty;
    if (control is ComboBox cmb)
        return cmb.Text == "Select ";
    if (control is DataGridView dgv)
        return dgv.DataSource == null;
    if (control is RichTextBox rtb)
        return rtb.Text == string.Empty;
    if (control is NumericUpDown nud)
        return nud.Value == 0;
    return true;
}
private void Clear(Control control)
{
    if (control is TextBox txt)
        txt.Clear();
    else if (control is ComboBox cmb)
        cmb.Text = "Select ";
    else if (control is DataGridView dgv)
        dgv.DataSource = null;
    else if (control is RichTextBox rtb)
        rtb.Clear();
    else if (control is NumericUpDown nud)
        nud.Value = 0;
}
