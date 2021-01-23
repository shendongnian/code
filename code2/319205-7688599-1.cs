    public class UpperCaseBehavior: Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
        }
        private void AssociatedObjectOnTextChanged(object sender, TextChangedEventArgs args)
        {
            var selectionStart = AssociatedObject.SelectionStart;
            var selectionLength = AssociatedObject.SelectionLength;
            AssociatedObject.Text = AssociatedObject.Text.ToUpper();
            AssociatedObject.SelectionStart = selectionStart;
            AssociatedObject.SelectionLength = selectionLength;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
            base.OnDetaching();
        }
    }
