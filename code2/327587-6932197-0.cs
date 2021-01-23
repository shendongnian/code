    public class NotInConverter : InConverter, IValueConverter
    {
      new public object Convert(...)
      {
        return !base.Convert(...);
      }
    
      new public object ConvertBack(...)
      {
        return !base.ConvertBack(...);
      }
    }
