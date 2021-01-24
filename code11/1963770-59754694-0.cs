    public class DataGridSelectedItemsBlendBehavior : Behavior<DataGrid>
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(object),
            typeof(DataGridSelectedItemsBlendBehavior ),
            new FrameworkPropertyMetadata(null) { BindsTwoWayByDefault = true });
        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += OnSelectionChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (this.AssociatedObject != null)
                this.AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItems != null)
            {
                foreach (var selectedItem in e.AddedItems)
                    if (!SelectedItems.Contains(selectedItem))
                        SelectedItems.Add(selectedItem);
                foreach (var unselectedItem in e.RemovedItems)
                    SelectedItems.Remove(unselectedItem);
            }
        }
    }
