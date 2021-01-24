    // Constructor
    public CustomSplitButton()
    {
      this.Loaded += GetParts;
    }
    
    private void GetParts(object sender, RoutedEventArgs e)
    {
      if (this.TryFindVisualChildElementByName("PART_Popup", out FrameworkElement popupPart))
      {
        if (popupPart.TryFindVisualChildElementByName("PART_ContentPresenter", out FrameworkElement contentPresenter))
        {
          if (!contentPresenter.IsLoaded)
          {
            contentPresenter.Loaded += CompleteSearch;
          }
          else 
          {
            CompleteSearch(contentPresenter, null);
          }
        }
      }
    }
    private void CompleteSearch(object sender, RoutedEventArgs e)
    {      
      contentPresenter.Loaded -= CompleteSearch;
      if ((sender as DependencyObject).TryFindVisualChildElementByName("PART_IncreaseButton", out FrameworkElement increaseButton))
      {        
        IncrementButton = (RepeatButton) increaseButton;
      }
    }
