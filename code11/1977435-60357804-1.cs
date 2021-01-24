    public class ShowErrorBehavior : Behavior<MySfTextInputLayout>
    {
        protected override void OnAttachedTo(MySfTextInputLayout entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(MySfTextInputLayout entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            ((MySfTextInputLayout)sender).HasErrors = string.IsNullOrWhiteSpace(args.NewTextValue);
        }
    }
