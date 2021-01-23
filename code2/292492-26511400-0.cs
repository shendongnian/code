    public class LimitSelectionBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty LimitProperty;
        
        static LimitSelectionBehavior()
        {
            LimitProperty = DependencyProperty.Register("Limit", typeof(int), typeof(LimitSelectionBehavior), new PropertyMetadata(default(int)));
        }
        public int Limit
        {
            get { return (int) GetValue(LimitProperty); }
            set { SetValue(LimitProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssociatedObject.SelectedItems.Count <= Limit)
                return;
            foreach (var added in e.AddedItems)
            {
                AssociatedObject.SelectedItems.Remove(added);
            }
        }
    }
