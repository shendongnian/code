    private void ClearControls(Control parent)
    {
        if ((parent == null) || (!parent.HasChildren))
            return;
        foreach (var ctl in parent.Controls.OfType<Control>())
        {
            if (ctl is TextBox txt) {
                txt.Clear();
            }
            if (ctl is CheckBox chk) {
                chk.Checked = false;
            }
            else {
                if (ctl.HasChildren) {
                    ClearControls(ctl);
                }
            }
        }
    }
