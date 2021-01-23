<!-- -->
    // This method could be used for all columns,
    // as long as they provide the necessary info:
    //     - Item Collection
    //     - Property Name
    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
    	var cb = sender as CheckBox;
    	var items = cb.Tag as IEnumerable;
    	PropertyInfo prop = null;
    	foreach (var item in items)
    	{
    		if (prop == null)
    		{
    			var type = item.GetType();
    			var propname = cb.Content as string;
    			prop = type.GetProperty(propname);
    		}
    		prop.SetValue(item, cb.IsChecked, null);
    	}
    }
