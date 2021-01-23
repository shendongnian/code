    public class ExecuteCommand : TriggerAction<DependencyObject>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ExecuteCommand), null);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ExecuteCommand), null);
        public UIElement CommandTarget
        {
            get { return (UIElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(UIElement), typeof(ExecuteCommand), null);
        protected override void Invoke(object parameter)
        {
            if (Command is RoutedCommand)
            {
                var routedCommand = Command as RoutedCommand;
                var commandTarget = CommandTarget ?? AssociatedObject as UIElement;
                if (routedCommand.CanExecute(CommandParameter, commandTarget))
                    routedCommand.Execute(CommandParameter, commandTarget);
            }
            else
            {
                if (Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
            }
        }
    }
