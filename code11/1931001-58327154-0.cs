public static readonly DependencyProperty AgeProperty = DependencyProperty.Register(
    "Age",
    typeof(int),
    typeof(Person),
    new FrameworkPropertyMetadata(
        0,
        callback
    ),
    new ValidateValueCallback(IsValidAge)
);
and then
public static bool IsValidAge(object value)
{
    int v = (int)value;
    return (v > 0 && v < 150);
}
