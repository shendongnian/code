public class TabItemExt : ItemsControl
{
    public TabItemExt() => SimplifiedItems = new ObservableCollection<Control>();
    public string Header
    {
      get { return (string)GetValue(HeaderProperty); }
      set { SetValue(HeaderProperty, value); }
    }
    // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(string), typeof(TabItemExt), new PropertyMetadata(String.Empty));
    public ObservableCollection<Control> SimplifiedItems
    {
      get { return (ObservableCollection<Control>)GetValue(SimplifiedItemsProperty); }
      set { SetValue(SimplifiedItemsProperty, value); }
    }
    // Using a DependencyProperty as the backing store for SimplifiedItems.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SimplifiedItemsProperty =
        DependencyProperty.Register("SimplifiedItems", typeof(ObservableCollection<Control>), typeof(TabItemExt), new PropertyMetadata(null));
}
