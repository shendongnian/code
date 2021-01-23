        string messageBoxText = "Do you want to save changes?";
        string caption = "Your caption";
        MessageBoxButton button = MessageBoxButton.YesNoCancel;
        MessageBoxImage icon = MessageBoxImage.Warning;
        MessageBox.Show(messageBoxText, caption, button, icon);
