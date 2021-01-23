    private void btnSave_Click(object sender, EventArgs e)
    {
           if (validateForm())
           {
               DialogResult = DialogResult.Yes;
               Close();
           }
           else
           {
               DialogResult = DialogResult.None;
           }
    }
