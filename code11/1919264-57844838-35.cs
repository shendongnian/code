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
      var originalSource = routedEventArgs.OriginalSource as DependencyObject;
      var isPartToggleButtonClicked = 
        object.ReferenceEquals(routedEventArgs.Source, this) 
          && (originalSource.TryFindVisualParentElement(out ButtonBase button) 
              && button.Name.Equals(this.PartTogglleButton.Name, StringComparison.OrdinalIgnoreCase)
              || originalSource.TryFindVisualParentElementByName("PART_ContentPresenter", out FrameworkElement popupContentPresenter));
    
      this.PartPopup.IsOpen = this.IsOpen = isPartToggleButtonClicked;
    }
