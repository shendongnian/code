    public class WindowCloseBehaviour : Behavior<Window>
    {
        public static readonly DependencyProperty CommandProperty =
          DependencyProperty.Register(
          "Command",
          typeof(ICommand),
          typeof(WindowCloseBehaviour));
        public static readonly DependencyProperty CommandParameterProperty =
              DependencyProperty.Register(
              "CommandParameter",
              typeof(object),
              typeof(WindowCloseBehaviour));
        public static readonly DependencyProperty CloseButtonProperty =
          DependencyProperty.Register(
          "CloseButton",
          typeof(Button),
          typeof(WindowCloseBehaviour),
          new FrameworkPropertyMetadata(
                    null,
                    OnButtonChanged));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public Button CloseButton
        {
            get { return (Button)GetValue(CloseButtonProperty); }
            set { SetValue(CloseButtonProperty, value); }
        }
        private static void OnButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)((WindowCloseBehaviour)d).AssociatedObject;
            ((Button) e.NewValue).Click += (s, e1) =>
                                               {
                                                   var command = ((WindowCloseBehaviour)d).Command;
                                                   var commandParameter = ((WindowCloseBehaviour)d).CommandParameter;
                                                   if (command != null)
                                                   {
                                                       command.Execute(commandParameter);                                                      
                                                   }
                                                   window.Close();
                                               };
        }
    }
