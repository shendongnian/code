    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    public class ScrollSelectedIntoView : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }
    
        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssociatedObject?.ScrollIntoView(AssociatedObject?.SelectedItem);
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
    
            base.OnDetaching();
        }
    }
