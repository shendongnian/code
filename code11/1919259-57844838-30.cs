    public CustomSplitButton()
    {
      this.Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      Mouse.AddPreviewMouseDownHandler(Application.Current.MainWindow, KeepPopUpOpen);
    }
    private void KeepPopupOpen(object sender, RoutedEventArgs routedEventArgs)
    {
      var isPartToggleButtonClicked = 
        object.ReferenceEquals(routedEventArgs.Source, this) 
          && (routedEventArgs.OriginalSource as DependencyObject).TryFindVisualParentElement(out ButtonBase button) 
          && button.Name.Equals(this.PartToggleButton.Name, StringComparison.OrdinalIgnoreCase);
    
      this.PartPopup.IsOpen = this.IsOpen = isPartToggleButtonClicked;
    }
