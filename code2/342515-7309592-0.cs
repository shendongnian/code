    public void OnRadioButtonSelected(object sender, SomeEventArgs e)
    {
      if(IsAnswered != null)
        IsAnswered(true);
    }
