    public class SetWindowSizeBehavior : Behavior<FrameworkElement>
    {
    
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (AssociatedObject == null)
            {
                // so, let'save the value and then reuse it when OnAttached() called
                _value = e.NewValue as string;
                return;
            }
    
            if (e.Property == PasswordProperty)
            {
                if (!_skipUpdate)
                {
                    _skipUpdate = true;
                    AssociatedObject.Password = e.NewValue as string;
                    _skipUpdate = false;
                }
            }
        }
        protected override void OnDetaching()
        {
            Console.WriteLine("detaching");
            base.OnDetaching();
        }
    
        protected override void OnAttached()
        {
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
    
            base.OnAttached();
        }
    
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("");
            var a = AssociatedObject;
        }
    
        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            Detach();
        }
    }
