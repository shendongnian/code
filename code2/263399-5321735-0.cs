    public class MyDataGrid : DataGrid
    {
        public static readonly DependencyProperty HandleKeyPressEventProperty =
            DependencyProperty.RegisterAttached("HandleKeyPressEvent",
                                                typeof(bool),
                                                typeof(MyDataGrid),
                                                new UIPropertyMetadata(true));
        public static bool GetHandleKeyPressEvent(DependencyObject obj)
        {
            return (bool)obj.GetValue(HandleKeyPressEventProperty);
        }
        public static void SetHandleKeyPressEvent(DependencyObject obj, bool value)
        {
            obj.SetValue(HandleKeyPressEventProperty, value);
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (GetHandleKeyPressEvent(CurrentCell.Column) == true)
            {
                HandleKeyPress(e);
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }
    }
