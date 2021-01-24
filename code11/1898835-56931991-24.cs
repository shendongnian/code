    public partial class MenuTree : UserControl
    {
      public static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register(
        "SelectedPage",
        typeof(object),
        typeof(TreeIndex),
        new PropertyMetadata(default(object)));
    
      public object SelectedPage
      {
        get { return (object) GetValue(TreeIndex.SelectedPageProperty); }
        set { SetValue(TreeIndex.SelectedPageProperty, value); }
      }
      public MenuTree ()
      {
        InitializeComponent();
      }
    
      private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
      {
        this.SelectedPage = e.NewValue;
      }
    }
