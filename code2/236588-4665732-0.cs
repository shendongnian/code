    public void AddControls(Form frm)
    {
        TextBox txtbx = new TextBox();
        txtbx.Text = "asd" + x.ToString();
        txtbx.Name = "txtbx" + x.ToString();
        txtbx.Location = new Point(10, (20 * x));
        txtbx.Height = 20;
        txtbx.Width = 50;
        frm.Controls.Add(txtbx);
    }
