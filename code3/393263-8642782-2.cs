      public class CardFieldTemplateSelector : IValueConverter
        {
        
                public DataTemplate CityNameTemplate { get; set; } 
        
                public DataTemplate StateNameTemplate { get; set; }
        
        
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    string fieldTag = (string) value;
                    switch (fieldTag)
                    {
                        case "City":
                            return CityNameTemplate;
                        case "State":
                            return StateNameTemplate;
                    }
        
                    throw new ArgumentOutOfRangeException();
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotSupportedException();
                }
            }
