    public class ColorValueConverter : IValueConverter
     {
         //IT" foreground must be "Red" - If ComboBoxColumn have value "R&D" foreground must be "Yellow"
        
         public object Convert(object value, Type targetType, object parameter, string language)
         {
             var solorbrush = new SolidColorBrush();
             switch (value.ToString())
             {
                 case "IT":
                     solorbrush.Color = Colors.Red;
                     break;
                 case "R&D":
                     solorbrush.Color = Colors.Yellow;
                     break;
                 case "Finance":
                     solorbrush.Color = Colors.Black;
                     break;
    
                 default:
                     solorbrush.Color = Colors.LightBlue;
                     break;
    
             }
             return solorbrush;
         }
   
      public object ConvertBack(object value, Type targetType, object parameter, string language)
         {
             throw new NotImplementedException();
         }
     }
