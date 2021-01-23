    public class SelectOnMouseUpListBoxItem : ListBoxItem
    {
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            var received = _receivedMouseDown;
            _receivedMouseDown = null;
            // validate that the mouse left button down event was called on this list box item
            if (received != this)
                return;
            var parent = WpfUtility.FindVisualParent<SelectOnMouseUpListBox>(this);
            parent.NotifyListItemClickedImp(this, e.ChangedButton);
            base.OnMouseLeftButtonUp(e);
        }
        private SelectOnMouseUpListBoxItem _receivedMouseDown;
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _receivedMouseDown = this;
            e.Handled = true;
            base.OnMouseLeftButtonDown(e);
        }
    }
    public class SelectOnMouseUpListBox : ListBox
    {
        static SelectOnMouseUpListBox()
        {
            _notifyListItemClickedMethodInfo = typeof(ListBox).GetMethod("NotifyListItemClicked", BindingFlags.Instance | BindingFlags.NonPublic);
            if (_notifyListItemClickedMethodInfo == null)
                throw new NotSupportedException("Failed to get NotifyListItemClicked method info by reflection");
        }
        private static readonly MethodInfo _notifyListItemClickedMethodInfo;
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SelectOnMouseUpListBoxItem();
        }
        public void NotifyListItemClickedImp(ListBoxItem item, MouseButton button)
        {
            _notifyListItemClickedMethodInfo.Invoke(this, new object[] {item, button});
        }
    }
