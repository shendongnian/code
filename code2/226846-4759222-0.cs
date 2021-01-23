        public class BaseExtendedListUserControl : UserControl
    {
        DependencyProperty ListVerticalOffsetProperty = DependencyProperty.Register(
          "ListVerticalOffset",
          typeof(double),
          typeof(BaseExtendedListUserControl),
          new PropertyMetadata(new PropertyChangedCallback(OnListVerticalOffsetChanged)));
        private ScrollViewer _listScrollViewer;
        protected void EnsureBoundToScrollViewer()
        {
            if (_listScrollViewer != null)
                return;
            var elements = VisualTreeHelper.FindElementsInHostCoordinates(new Rect(0,0,this.Width, this.Height), this);
            _listScrollViewer = elements.Where(x => x is ScrollViewer).FirstOrDefault() as ScrollViewer;
            if (_listScrollViewer == null)
                return;
            Binding binding = new Binding();
            binding.Source = _listScrollViewer;
            binding.Path = new PropertyPath("VerticalOffset");
            binding.Mode = BindingMode.OneWay;
            this.SetBinding(ListVerticalOffsetProperty, binding);
        }
        public double ListVerticalOffset
        {
            get { return (double)this.GetValue(ListVerticalOffsetProperty); }
            set { this.SetValue(ListVerticalOffsetProperty, value); }
        }
        private static void OnListVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BaseExtendedListUserControl control = obj as BaseExtendedListUserControl;
            control.OnListVerticalOffsetChanged();
        }
        private void OnListVerticalOffsetChanged()
        {
            OnListVerticalOffsetChanged(_listScrollViewer);
        }
        
        protected virtual void OnListVerticalOffsetChanged(ScrollViewer s)
        {
            // do nothing
        }
    }
