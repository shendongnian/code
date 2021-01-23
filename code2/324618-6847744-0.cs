    void OnNoEvent(object sender, EventArgs e)
    {
       if (MessageBox.Show("Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
       {
          this.DialogResult = DialogResult.No;
          this.Close();
       }
    }
    
    void OnYesEvent(object sender, EventArgs e)
    {
       this.DialogResult = DialogResult.Yes;
       this.Close();
    }
