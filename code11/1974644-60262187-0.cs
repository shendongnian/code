    public class DoSomethingOnTextChanged: Behavior<>
    {
    
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }
        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
           var newTextValue = (string)e.NewTextValue;
           //Do Some Logic
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
