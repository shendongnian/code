    public string Text
    {
      get
      {
        EnsureChildControls();
        return label.Text;
      }
    
      set
      {
        EnsureChildControls();
        label.Text = value;
      }
    }
