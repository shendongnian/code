    // Constructor
    public CustomSplitButton()
    {
      this.Loaded += GetParts;
    }
    
    private void GetParts(object sender, RoutedEventArgs e)
    {
      if (this.TryFindVisualChildElementByName("PART_Popup", out Popup popupPart))
      {
        if (popupPart.TryFindVisualChildElementByName("PART_Spinner", out ButtonSpinner buttonSpinner))
        {
          // Do something with buttonSpinner
        }
    
        if (popupPart.TryFindVisualChildElementByName("MyCustomIntegerUpDown", out CustomIntegerUpDown customIntegerUpDown))
        {
          // Do something with customIntegerUpDown
        }
    
        if (popupPart.TryFindVisualChildElementByName("PART_IncreaseButton", out RepeatButton increaseButtonPart))
        {
          // Do something with increaseButtonPart
        }
      }
    }
