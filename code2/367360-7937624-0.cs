    public event EventHandler TheButtonClicked;
    // Constructor
    public CustomWindow()
    {
      theButton.Click += FireTheButtonClicked;
    }
    public void FireTheButtonClicked(object sender, EventArgs e)
    {
      if(TheButtonClicked != null) TheButtonClicked(this, e);
    }
