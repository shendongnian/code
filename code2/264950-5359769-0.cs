    public override void btnReset_Click(object sender, EventArgs e)
    {
      // do form specific stuff here
      someButton.Text = String.Empty;      
      
      // then invoke base method
      base.btnReset_Click(sender, e);
    }
