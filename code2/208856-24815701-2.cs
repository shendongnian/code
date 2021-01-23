c#
private void btnExit_Click(object sender, EventArgs e)
{
    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
    {
        if (Application.OpenForms[i].Name != "Menu")
            Application.OpenForms[i].Close();
    }
}
