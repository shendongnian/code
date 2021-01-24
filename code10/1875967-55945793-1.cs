    public YourClass()
    {
      InitializeComponent();
      foreach(var C in this.Controls.OfType<CheckBox>().Where(c => c.Tag == "yourTag"))
        c.ValueChanged += ValueChanged;
    }
    private void ValueChanged(object sender, System.EventArgs e) 
    {
      this.CalculateQuote();
    }
