C#
public class Messages
{
    public int MsgStatus { get; set; }
}
and i changed your convert to this (look at line 2):
C#
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    var input = System.Convert.ToInt16(value);
    switch (input)
    {
        case 1:
            return MaterialDesignThemes.Wpf.PackIconKind.Alarm;
        case 2:
            return MaterialDesignThemes.Wpf.PackIconKind.Message;
        default:
            return DependencyProperty.UnsetValue;
    }
}
and it's work for me. Output:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/0UJa9.jpg
