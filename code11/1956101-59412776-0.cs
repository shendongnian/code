    public class ImageConverter : IValueConverter
     {
         public UIElement UIParameter { get; set; }
         public object Convert(object value, Type targetType, object parameter, string language)
         {
             var rootGrid = UIParameter as Grid;
             if(parameter != null)
             {
                 var ele = rootGrid.FindName(parameter.ToString());
    
             }
            
             return value;
         }
     }
