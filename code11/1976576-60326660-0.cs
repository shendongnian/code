    public partial class TableSelectorControl : UserControl
    {
        private Brush _cellHoverBrush = new SolidColorBrush(Colors.CadetBlue) { Opacity = 0.3 };
        public static readonly DependencyProperty ActiveSelectionProperty =
            DependencyProperty.Register("ActiveSelection", typeof(TableSelectorSelection),
                typeof(TableSelectorControl), new PropertyMetadata(new PropertyChangedCallback(OnActiveSelectionChanged)));
        public TableSelectorSelection ActiveSelection
        {
            get => (TableSelectorSelection)GetValue(ActiveSelectionProperty);
            set => SetValue(ActiveSelectionProperty, value);
        }
        private static void OnActiveSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tableSelCtrl = d as TableSelectorControl;
            if (tableSelCtrl != null)
            {
                tableSelCtrl._cellHoverBrush = (e.NewValue as TableSelectorSelection)?.HoverBrush;
            }
        }
    }
 
