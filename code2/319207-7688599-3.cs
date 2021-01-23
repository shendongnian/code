    public class UpperCaseBehavior: Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += AssociatedObject_TextChanged;
        }
        private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs args)
        {
            var selectionStart = AssociatedObject.SelectionStart;
            var selectionLength = AssociatedObject.SelectionLength;
            AssociatedObject.Text = AssociatedObject.Text.ToUpper();
            AssociatedObject.SelectionStart = selectionStart;
            AssociatedObject.SelectionLength = selectionLength;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
            base.OnDetaching();
        }
    }
