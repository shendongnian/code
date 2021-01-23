        private static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            ICommand command = (ICommand)control.GetValue(CommandProperty);
            object commandParameter = control.GetValue(CommandParameterProperty);
           //Check command can execute!!  
          if(command.CanExecute(commandParameter ))
             command.Execute(commandParameter);
        }
