    class MainWindowViewModel : IDialogViewModelProvider
    {
      public void ShowDialog()
      {  
        // Create the IDialogViewModel for the File Exists dialog
        var dialogTitleBarIcon = new BitmapImage(new Uri("../../logo.ico", UriKind.Relative));
        if (titleBarIcon.CanFreeze)
        {
          titleBarIcon.Freeze();
        }
        
        var message = "File exists. Do you want to replace it?";
        var dialogTitle = "File Exists";
          
        // Set the continuation callback which will be invoked once the dialog closed
        var fileExistsdialogViewModel = new FileExistsDialogViewModel(
          message, 
          dialogTitle, 
          dialogTitleBarIcon, 
          dialogViewModel => HandleFileExistsDialogResponseAsync(dialogViewModel, filePath, settingsData));
        
        // Show the dialog by setting the DialogViewModel property to an instance of IDialogViewModel
        this.DialogViewModel = fileExistsdialogViewModel;
      }
      
      // Continuation callback. Will be invoked once the dialog closed. 
      // The parameter is the previously created FileExistsDialogViewmodel containing data set from the dialog.
      private async Task HandleFileExistsDialogResponseAsync(IDialogViewModel dialogViewModel, string filePath, string settingsData)
      {
        if (dialogViewModel.DialogResult == DialogResult.Accepted)
        {
          await SaveFileAsync(filePath, settingsData);
        }
      }
      
      // IDialogViewModelProvider interface implementation
      private IDialogViewModel dialogViewModel;  
      public IDialogViewModel DialogViewModel
      {
        get => this.dialogViewModel;
        private set => TrySetValue(value, ref this.dialogViewModel);
      }
    }
