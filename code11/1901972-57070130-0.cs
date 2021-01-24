    public class ComboBoxSelectionChangedBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ....
        }
        
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }
    }
