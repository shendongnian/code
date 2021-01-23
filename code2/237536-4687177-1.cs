    class ScrollBehavior : Behavior<FrameworkElement>
    {
        public int LineMultiplier
        {
            get { return (int)GetValue(LineMultiplierProperty); }
            set { SetValue(LineMultiplierProperty, value); }
        }
        public static readonly DependencyProperty LineMultiplierProperty =
            DependencyProperty.Register("LineMultiplier", typeof(int), typeof(ScrollBehavior), new UIPropertyMetadata(1));
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }
        private ScrollViewer scrollViewer;
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            scrollViewer = GetScrollViewer(AssociatedObject);
            scrollViewer.CommandBindings.Add(new CommandBinding(ScrollBar.LineUpCommand, LineCommandExecuted));
            scrollViewer.CommandBindings.Add(new CommandBinding(ScrollBar.LineDownCommand, LineCommandExecuted));
        }
        private void LineCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ScrollBar.LineUpCommand)
            {
                for (int i = 0; i < LineMultiplier; i++)
                    scrollViewer.LineUp();
            }
            if (e.Command == ScrollBar.LineDownCommand)
            {
                for (int i = 0; i < LineMultiplier; i++)
                    scrollViewer.LineDown();
            }
        }
        private ScrollViewer GetScrollViewer(DependencyObject o)
        {
            if (o is ScrollViewer)
                return o as ScrollViewer;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var result = GetScrollViewer(VisualTreeHelper.GetChild(o, i));
                if (result != null)
                    return result;
            }
            return null;
        }
    }
