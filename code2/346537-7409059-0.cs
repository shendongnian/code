    public static readonly DependencyProperty Border2Property =
        DependencyProperty.RegisterAttached("Border2", typeof(Border), typeof(A));
    public static Border GetBorder2(DependencyObject obj)
    {
        return (Border) obj.GetValue(Border2Property);
    }
    public static void SetBorder2(DependencyObject obj, Border2 value)
    {
        obj.SetValue(Border2Property, value);
    }
