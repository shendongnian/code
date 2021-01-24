    // Constructor
    public CustomSplitButton()
    {
      this.Loaded += GetParts;
    }
    
    private void GetParts(object sender, RoutedEventArgs e)
    {
      if (this.TryFindVisualChildElementByName("PART_Popup", out FrameworkElement popupPart))
      {
        if (popupPart.TryFindVisualChildElementByName("MyCustomIntegerUpDown", out FrameworkElement buttonSpinner))
        {
          if (!buttonSpinner.IsLoaded)
          {
            buttonSpinner.Loaded += CompleteSearch;
          }
          else 
          {
            CompleteSearch(buttonSpinner, null);
          }
        }
      }
    }
    private void CompleteSearch(object sender, RoutedEventArgs e)
    {
      if ((sender as DependencyObject).TryFindVisualChildElementByName("PART_IncreaseButton", out FrameworkElement increaseButton))
      {        
        IncrementButton = (RepeatButton) increaseButton;
      }
    }
