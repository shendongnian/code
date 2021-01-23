    public bool TryClose()
    {
        MessageBoxResult result = MessageBox.Show("Do you want to save changes?", appName, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
       switch (result)
       {
           case MessageBoxResult.Yes:
               SaveAs();
               return false;
           case MessageBoxResult.No:
               this.Close();
               return false;
       }
       return true;
    }
