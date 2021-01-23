    public event EventHandler OnPreviousClicked;
    
    private void PreviousButton_OnClick(object sender, EventArgs e)
    {
      if(OnPreviousClicked != null) {
        OnPreviousClicked(this, e); // or whatever args you want
      }
    }
