    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedIndexProperty =
        DependencyProperty.Register("SelectedIndex", typeof(int), typeof(UserControl1), new UIPropertyMetadata(0));
