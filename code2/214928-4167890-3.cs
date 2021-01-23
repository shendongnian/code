    public static T SetToolTip<T>(
           this T element, object value)
           where T : System.Windows.DependencyObject
    {
        System.Windows.Controls.ToolTipService.SetToolTip(element, value);
        return element;
    }
