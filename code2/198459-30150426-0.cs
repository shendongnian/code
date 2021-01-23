    private void OkBtn_Click(object sender, EventArgs e)
    {
        if (isValid())
        { 
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
    }
