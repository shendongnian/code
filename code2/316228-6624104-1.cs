    public class FilterConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
         var list=value as List<Product>();
         if (list==null) return Binding.DoNothing;
         var stringPrice=parameter as string;
         int price;
         if (!int.TryParse(stringPrice,out price)) return Binding.DoNothing;
         return list.Where(i=>i.Price==price).ToList();
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return Binding.DoNothing;
      }
 
    }
