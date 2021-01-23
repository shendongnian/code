    public class DataGridSortedColumnHighlightBehavior : Behavior<DataGrid>
    {
        private List<DataGridRow> rows = new List<DataGridRow>();
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LoadingRow += AssociatedObject_LoadingRow;
            AssociatedObject.UnloadingRow += AssociatedObject_UnloadingRow;
            if (AssociatedObject.ItemsSource == null)
            {
                AssociatedObject.LayoutUpdated += AssociatedObject_LayoutUpdated;
            }
            else
            {
                var collection =
                    ((AssociatedObject.ItemsSource as PagedCollectionView).SortDescriptions as INotifyCollectionChanged);
                collection.CollectionChanged += DataGridSortedColumnHighlightBehavior_CollectionChanged;
            }
        }
        void AssociatedObject_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            rows.Remove(e.Row);
        }
        void AssociatedObject_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            rows.Add(e.Row);
        }
        private void AssociatedObject_LayoutUpdated(object sender, EventArgs e)
        {
            if (AssociatedObject.ItemsSource != null)
            {
                AssociatedObject.LayoutUpdated -= AssociatedObject_LayoutUpdated;
                var collection =
                    ((AssociatedObject.ItemsSource as PagedCollectionView).SortDescriptions as INotifyCollectionChanged);
                collection.CollectionChanged += DataGridSortedColumnHighlightBehavior_CollectionChanged;
            }
        }
        void DataGridSortedColumnHighlightBehavior_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
            {
                foreach(SortDescription sortDesc in e.NewItems)
                {
                    foreach(var column in AssociatedObject.Columns)
                    {
                        var boundColumn = column as DataGridBoundColumn;
                        if (boundColumn == null)
                            continue;
                        if (boundColumn.Binding.Path.Path == sortDesc.PropertyName)
                        {
                            foreach (var row in rows)
                                ColorCell(column,row,Colors.Red);
                        }
                    }
                }
            }
            if(e.OldItems != null)
            {
                foreach(SortDescription sortDesc in e.OldItems)
                {
                    foreach(var column in AssociatedObject.Columns)
                    {
                        var boundColumn = column as DataGridBoundColumn;
                        if (boundColumn == null)
                            continue;
                        if (boundColumn.Binding.Path.Path == sortDesc.PropertyName)
                        {
                            foreach (var row in rows)
                                ColorCell(column,row,Colors.White);
                        }
                    }
                }
            }
        }
        private void ColorCell(DataGridColumn column, DataGridRow item, Color color )
        {
            var content = column.GetCellContent(item);
            if (content == null)
                return;
            var parent = GetParent<DataGridCell>(content);
            if (parent != null)
                parent.Background = new SolidColorBrush(color);
        }
        public static T GetParent<T>(DependencyObject source)
            where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(source);
            while (parent != null && !typeof(T).IsAssignableFrom(parent.GetType()))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return (T)parent;
        }        
    }
