    public static void ButtonListUpdated(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        var control = source as RibbonBarUserControl;
        var buttons = e.OldValue as ObservableCollection<Button>;
        if (buttons != null)
            buttons.CollectionChanged -= control.OnCollectionChanged;
        buttons = e.NewValue as ObservableCollection<Button>;
        if (buttons != null)
            buttons.CollectionChanged += control.OnCollectionChanged;
        control.UpdateButtons();
    }
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        this.UpdateButtons();
    }
    private void UpdateButtons() {
        // TODO: Update buttons
    }
