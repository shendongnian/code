    public class DoubleMe : MarkupExtension, IValueConverter
    {
       public override object ProvideValue(IServiceProvider serviceProvider)
       {
          return this;
       }
       public object Convert(object value, /*rest of parameters*/ )
       {
           if ( value is int )
                 return (int)(value) * 2; //double it
           else
                return value.ToString() + value.ToString();
       }
       //...
    }
