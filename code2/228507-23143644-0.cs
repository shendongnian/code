    public class MouseDoubleClickBehavior : Behavior<Control>
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof (ICommand), typeof (MouseDoubleClickBehavior), new PropertyMetadata(default(ICommand)));
    
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof (object), typeof (MouseDoubleClickBehavior), new PropertyMetadata(default(object)));
    
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseDoubleClick += OnMouseDoubleClick;
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.MouseDoubleClick -= OnMouseDoubleClick;
            base.OnDetaching();
        }
    
        void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (Command == null) return;
            Command.Execute(/*commandParameter*/null);
        }
    }
