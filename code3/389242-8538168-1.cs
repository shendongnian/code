    private void dtgrd1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var txtEdit = (TextBox)e.Control;
        txtEdit.KeyPress += EditKeyPress; //where EditKeyPress is your keypress event
    }
    private void EditKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; //suppress ENTER
                    //SendKeys.Send("{Tab}"); //Next column (or row)
                    base.OnKeyDown(e);
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    base.OnKeyDown(e);
                    this.BeginEdit(false);
                }
                else
                {
                    base.OnKeyDown(e);
                }
    }
