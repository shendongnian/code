    public class DataGridColumnHeaderReleaseMouseCaptureBehavior {
        public static DataGrid GetReleaseDGCHeaderBehavior(DependencyObject obj) {
            return (DataGrid)obj.GetValue(ReleaseDGCHeaderBehaviorProperty);
        }
        public static void SetReleaseDGCHeaderBehavior(DependencyObject obj, Boolean value) {
            obj.SetValue(ReleaseDGCHeaderBehaviorProperty, value);
        }
        public static readonly DependencyProperty ReleaseDGCHeaderBehaviorProperty =
            DependencyProperty.RegisterAttached("ReleaseDGCHeaderBehavior",
                typeof(DataGrid),
                typeof(DataGridColumnHeaderReleaseMouseCaptureBehavior),
                new UIPropertyMetadata(default(DataGrid), OnReleaseDGCHeaderBehaviorPropertyChanged));
        private static Popup _popup;
        private static void OnReleaseDGCHeaderBehaviorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var oldGrid = (DataGrid)e.OldValue;
            if (oldGrid != null)
                oldGrid.MouseLeave -= OnMouseLeave;
            var refSender = d as Popup;
            _popup = refSender;
            if (refSender != null) {
                var refGrid = e.NewValue as DataGrid;
                if (refGrid != null) {
                    refGrid.MouseLeave += OnMouseLeave;
                }
            }
        }
        static void OnMouseLeave(object sender, MouseEventArgs args) {
            if (_popup != null)
                typeof(Popup).GetMethod("EstablishPopupCapture", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(_popup, null);
        }
    }
