    private void Control_Clicks(object sender, EventArgs e)
    {
        Control control = (Control)sender;   // Sender gives you which control is clicked.
        MessageBox.Show(control.Name.ToString());
    }
