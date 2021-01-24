    public partial class MenuTree : UserControl
    {
      public static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register(
        "SelectedPage",
        typeof(object),
        typeof(MenuTree),
        new PropertyMetadata(default(object)));
    
      public object SelectedPage
      {
        get { return (object) GetValue(MenuTree.SelectedPageProperty); }
        set { SetValue(MenuTree.SelectedPageProperty, value); }
      }
      public MenuTree()
      {
        InitializeComponent();
      }
    
      private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
      {
        this.SelectedPage = e.NewValue;
      }
    }
