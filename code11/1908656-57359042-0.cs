    public static class DataGridBehavior
    {
        public static readonly DependencyProperty FocusFirstCellProperty = DependencyProperty.RegisterAttached(
            "FocusFirstCell", typeof(Boolean), typeof(DataGridBehavior), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnChanged)));
        public static void SetFocusFirstCell(DataGrid element, Boolean value)
        {
            element.SetValue(FocusFirstCellProperty, value);
        }
        public static Boolean GetFocusFirstCell(DataGrid element)
        {
            return (Boolean)element.GetValue(FocusFirstCellProperty);
        }
        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid element = (DataGrid)d;
            if (element.IsLoaded)
            {
                TextBox textBox = FindVisualChild<TextBox>(element);
                if (textBox != null)
                    Keyboard.Focus(textBox);
            }
            else
            {
                RoutedEventHandler handler = null;
                handler = (ss, ee) =>
                {
                    DataGrid dataGrid = (DataGrid)ss;
                    TextBox textBox = FindVisualChild<TextBox>((DataGrid)ss);
                    if (textBox != null)
                        Keyboard.Focus(textBox);
                    dataGrid.Loaded -= handler;
                };
                element.Loaded += handler;
            }
        }
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
