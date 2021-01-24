    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var currentItem = value;
        var name = "Not Converted";
        if (currentItem.GetType() != typeof(string))
        {
            var prop = currentItem.GetType().GetProperty("Name");
            var val = prop.GetValue(currentItem, null);
            name = val.ToString();
        }
        else
            name = currentItem.ToString();
        return name;
    }
