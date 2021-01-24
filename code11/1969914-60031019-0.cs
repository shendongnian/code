public partial class MyComboBox : ComboBox
	{
		static MyComboBox()
		{
			ItemsSourceProperty.OverrideMetadata(typeof(MyComboBox),
				new FrameworkPropertyMetadata((IEnumerable)null, new PropertyChangedCallback(OnItemsSourceChanged)));
		}
        
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ItemsControl ic = (ItemsControl)d;
			IEnumerable oldValue = (IEnumerable)e.OldValue;
			IEnumerable newValue = (IEnumerable)e.NewValue;
            // We get into infinite recursion land without the following condition:
			if (newValue.GetType() == typeof(Dictionary<int, string>))
			{
				ic.ItemsSource = new ListCollectionView(((Dictionary<int, string>)newValue).ToList());
            }
        }
        ...
Note that the `if (newValue.GetType() == typeof(Dictionary<int, string>))` condition is required, otherwise you get into an infinite recursion loop (MyComboBox sets ItemsControl.ItemsSource which changes the ItemsSourceProperty, which then triggers ic.OnItemsSourceChanged(oldValue, newValue) leading back to MyComboBox.OnItemsSourceChanged and so on.
**So the above works but it's pretty ugly. Is there really no better way?**
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/how-to-override-metadata-for-a-dependency-property
