    public CustomSplitButton()
    {
      this.Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      Mouse.AddPreviewMouseDownHandler(Application.Current.MainWindow, KeepPopUpOpen);
    }
    private void KeepOpen(object sender, RoutedEventArgs routedEventArgs)
    {
      var mouseClickSourceElement = routedEventArgs.OriginalSource as DependencyObject;
      var isPopupContentClicked = false;
      var isPartToggleButtonClicked = 
        object.ReferenceEquals(routedEventArgs.Source, this) 
          && mouseClickSourceElement.TryFindVisualParentElement(out ButtonBase button) 
          && button.Name.Equals(this.PartTogglleButton.Name, StringComparison.OrdinalIgnoreCase);
      if (!isPartToggleButtonClicked)
      {
        isPopupContentClicked = 
          object.ReferenceEquals(routedEventArgs.Source, this) 
            && mouseClickSourceElement.TryFindVisualParentElementByName("PART_ContentPresenter", out FrameworkElement popupContentPresenter));
      }
      this.PartPopup.IsOpen = this.IsOpen = isPartToggleButtonClicked || isPopupContentClicked ;
    }
