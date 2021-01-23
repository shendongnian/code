    private void ResetControl(Control control)
    {
      if (control.HasChildren)
        foreach (var ctl in control.Controls)
          ResetControl((Control)ctl);
      if (control is TextBox)
        control.ResetText();
    }
