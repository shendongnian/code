    public partial class EditorCommitHelper
    {
        public static readonly DependencyProperty CommitOnValueChangedProperty = DependencyProperty.RegisterAttached("CommitOnValueChanged", typeof(bool), typeof(EditorCommitHelper), new PropertyMetadata(CommitOnValueChangedPropertyChanged));
    
        public static void SetCommitOnValueChanged(GridColumn element, bool value)
        {
            element.SetValue(CommitOnValueChangedProperty, value);
        }
        public static bool GetCommitOnValueChanged(GridColumn element)
        {
            return (bool)element.GetValue(CommitOnValueChangedProperty);
        }
    
        private static void CommitOnValueChangedPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            GridColumn col = source as GridColumn;
            if (col.View == null)
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action<GridColumn, bool>((column, subscribe) => {
                    ToggleCellValueChanging(column, subscribe);
                }), col, (bool)e.NewValue);
            else
                ToggleCellValueChanging(col, (bool)e.NewValue);
        }
    
        private static void ToggleCellValueChanging(GridColumn col, bool subscribe)
        {
            TreeListView view = col.View as TreeListView;
            if (view == null)
                return;
    
            if (subscribe)
                view.CellValueChanging += new CellValueChangedEventHandler(view_CellValueChanging);
            else
                view.CellValueChanging -= view_CellValueChanging;
        }
    
        static void view_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            TreeListView view = sender as TreeListView;
    
            if ((bool)e.Column.GetValue(CommitOnValueChangedProperty))
                view.PostEditor();
        }
    }
