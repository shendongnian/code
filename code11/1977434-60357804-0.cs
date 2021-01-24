    public class MySfTextInputLayout : SfTextInputLayout
    {
    
        public MySfTextInputLayout ()
        {
            Behaviors.Add(new ShowErrorBehavior());
        }
        public bool HasErrors
        {
            get { return (bool)GetValue(HasErrorsProperty); }
            set { SetValue(HasErrorsProperty, value); }
        }
        public static readonly BindableProperty HasErrorsProperty =
            BindableProperty.Create(nameof(HasErrors), typeof(bool), typeof(MySfTextInputLayout ), false);
    
    }
