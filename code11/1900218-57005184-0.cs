    public class CharColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String ValueContent = String.Empty;
            String ForegroundColor = "#000000";
            
            String charValue = "!";
            //check if value is null
            if (value != null)
            {                
                ValueContent = (String)value;
                // Check for the char ! and change foreground colour 
                if (ValueContent.Contains(charValue)
                {
                    ForegroundColor = "#e40034";
                }
            }
            return ForegroundColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
