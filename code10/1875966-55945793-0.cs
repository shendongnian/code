    public YourClass()
    {
      YourCheckBox.ValueChanged += ValueChanged;
    }
    private void ValueChanged(object sender, System.EventArgs e) 
    {
      this.CalculateQuote();
    }
