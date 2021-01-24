    public partial class MenuTree : UserControl
    {
      public static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register(
        "SelectedPage",
        typeof(string),
        typeof(MenuTree),
        new PropertyMetadata("/landingPage.xaml"));
    
      public string SelectedPage
      {
        get { return (string) GetValue(MenuTree.SelectedPageProperty); }
        set { SetValue(MenuTree.SelectedPageProperty, value); }
      }
      public MenuTree()
      {
        InitializeComponent();
      }
    
      private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
      {
        this.SelectedPage = (e.NewValue as FrameworkElement)?.Tag as string;
      }
    }
