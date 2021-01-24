    public static readonly DependencyProperty SelectedItemProperty =
        System.Windows.Controls.Primitives.Selector.SelectedItemProperty.AddOwner(
            typeof(AdjacentControl));
    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
