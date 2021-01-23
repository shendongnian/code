    public class SourceToTabItemsConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    var source = (IEnumerable)value;
                    if (source != null)
                    {
                        var controlTemplate = (ControlTemplate)parameter;
    
                        var tabItems = new List<TabItem>();
    
                        foreach (object item in source)
                        {
                            PropertyInfo[] propertyInfos = item.GetType().GetProperties();
    
                            //тут мы выбираем, то поле которое будет Header. Вы должны сами вводить это значение.
                            var propertyInfo = propertyInfos.First(x => x.Name == "name");
    
                            string headerText = null;
                            if (propertyInfo != null)
                            {
                                object propValue = propertyInfo.GetValue(item, null);
                                headerText = (propValue ?? string.Empty).ToString();
                            }
    
                            var tabItem = new TabItem
                                              {
                                                  DataContext = item,
                                                  Header = headerText,
                                                  Content =
                                                      controlTemplate == null
                                                          ? item
                                                          : new ContentControl { Template = controlTemplate }
                                              };
    
                            tabItems.Add(tabItem);
                        }
    
                        return tabItems;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
    
            /// <summary>
            /// ConvertBack method is not supported
            /// </summary>
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException("ConvertBack method is not supported");
            }
