    public class ErrorsBehavior : Behavior<FrameworkElement>
    {
        public bool HasErrors
        {
            get => (bool )this.GetValue(HasErrorsProperty);
            set => this.SetValue(HasErrorsProperty, value);
        }
        public static readonly DependencyProperty HasErrorsProperty =
            DependencyProperty.Register(nameof(HasErrors), typeof(bool), typeof(ErrorsBehavior ), new PropertyMetadata(false));
        protected override void OnAttached()
        {
            AssociatedObject.SomeRoutedEvent += ...
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SomeRoutedEvent -= ...
        }
    }
