    using System.Windows;
    using System.Windows.Controls;
    public static class Index
    {
        private static readonly DependencyPropertyKey OfPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "Of",
            typeof(int),
            typeof(Index),
            new PropertyMetadata(-1));
        public static readonly DependencyProperty OfProperty = OfPropertyKey.DependencyProperty;
        public static readonly DependencyProperty InProperty = DependencyProperty.RegisterAttached(
            "In",
            typeof(DataGrid),
            typeof(Index),
            new PropertyMetadata(default(DataGrid), OnInChanged));
        public static void SetOf(this DataGridRow element, int value)
        {
            element.SetValue(OfPropertyKey, value);
        }
        public static int GetOf(this DataGridRow element)
        {
            return (int)element.GetValue(OfProperty);
        }
        public static void SetIn(this DataGridRow element, DataGrid value)
        {
            element.SetValue(InProperty, value);
        }
        public static DataGrid GetIn(this DataGridRow element)
        {
            return (DataGrid)element.GetValue(InProperty);
        }
        private static void OnInChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (DataGridRow)d;
            row.SetOf(row.GetIndex());
        }
    }
<!-- -->
