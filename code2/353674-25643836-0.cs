    public class DragDroppableListView : ListView
    {
        private IDisposable _subscription;
        public DragDroppableListView()
        {
            Loaded += OnControlLoaded;
            Unloaded += OnControlUnloaded;
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left) return;
            var obj = ContainerFromElement((Visual)e.OriginalSource);
            if (obj == null) return;
            var element = obj as FrameworkElement;
            if (element == null) return;
            var item = element as ListBoxItem;
            if (item == null) return;
            
            // select item
            item.IsSelected = true;
        }
        private void OnControlUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnControlLoaded;
            Unloaded -= OnControlUnloaded;
            if (_subscription != null)
                _subscription.Dispose();
        }
        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            var mouseDown = Observable.FromEventPattern<MouseButtonEventArgs>(this, "PreviewMouseDown");
            var mouseUp = Observable.FromEventPattern<MouseEventArgs>(this, "MouseUp");
            var mouseMove = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");
            _subscription = mouseDown
                .Where(a => a.EventArgs.LeftButton == MouseButtonState.Pressed)
                .Where(o => !IsScrollBar(o.EventArgs))
                .Do(o => o.EventArgs.Handled = true)        // not allow listview select on mouse down
                .Select(ep => ep.EventArgs.GetPosition(this))
                .SelectMany(md => mouseMove
                    .TakeWhile(ep => ep.EventArgs.LeftButton == MouseButtonState.Pressed)
                    .Where(ep => IsMinimumDragSeed(md, ep.EventArgs.GetPosition(this)))
                    .TakeUntil(mouseUp))
                .ObserveOnDispatcher()
                .Subscribe(_ => OnDrag());
        }
        private void OnDrag()
        {
            var item = GetItemUnderMouse();
            if (item == null) return;
            DragDrop.DoDragDrop(
                this,
                new DataObject(typeof(object), item),
                DragDropEffects.Copy | DragDropEffects.Move);
        }
        private ListViewItem GetItemUnderMouse()
        {
            return Items.Cast<object>()
                .Select(item => ItemContainerGenerator.ContainerFromItem(item))
                .OfType<ListViewItem>()
                .FirstOrDefault(lvi => lvi.IsMouseOver);
        }
        private static bool IsMinimumDragSeed(Point start, Point end)
        {
            return Math.Abs(end.X - start.X) >= SystemParameters.MinimumHorizontalDragDistance ||
                   Math.Abs(end.Y - start.Y) >= SystemParameters.MinimumVerticalDragDistance;
        }
        private bool IsScrollBar(MouseEventArgs args)
        {
            var res = VisualTreeHelper.HitTest(this, args.GetPosition(this));
            if (res == null) return false;
            var depObj = res.VisualHit;
            while (depObj != null)
            {
                if (depObj is ScrollBar) return true;
                // VisualTreeHelper works with objects of type Visual or Visual3D.
                // If the current object is not derived from Visual or Visual3D,
                // then use the LogicalTreeHelper to find the parent element.
                if (depObj is Visual || depObj is System.Windows.Media.Media3D.Visual3D)
                    depObj = VisualTreeHelper.GetParent(depObj);
                else
                    depObj = LogicalTreeHelper.GetParent(depObj);
            }
            return false;
        }
    }
