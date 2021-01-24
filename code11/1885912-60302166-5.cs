     private void Button_Close(object sender, RoutedEventArgs e)
     {
            bool? Result = new MessageBoxCustom("Are you sure, You want to close 
            application ?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
    
            if (Result.Value)
            {
                Application.Current.Shutdown();
            }
        }
