    public event EventHandler CancelClicked;
    protected Cancel_Click(object sender, EventArgs e)
    {
      if(CancelClicked != null)
      {
        CancelClicked(this, e);
      }
    }
