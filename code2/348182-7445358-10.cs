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
      In XAML, you can directly use it without creating a StaticResource:
        <TextBlock Text="{Binding Name, Converter={local:DoubleMe}}"/>
        <TextBlock Text="{Binding Age, Converter={local:DoubleMe}}"/>
      Such code is very handy when debugging, as you can just write `local:DebugMe` and then can debug the DataContext of the control on which you use it.
