    class MainWindowViewModel
    {
      public void ShowFileAlreadyExistsDialog()
      {  
        // Initialize the DialogViewModel implementation for the File Exists dialog
        var dialogTitleBarIcon = new BitmapImage(new Uri("../../logo.ico", UriKind.Relative));
        if (titleBarIcon.CanFreeze)
        {
          titleBarIcon.Freeze();
        }
        
        var message = "File exists. Do you want to replace it?";
        var dialogTitle = "File Exists";
          
        // Set the continuation callback which will be invoked once the dialog closed
        DialogViewModel fileExistsdialogViewModel = new FileExistsDialogViewModel(
          message, 
          dialogTitle, 
          dialogTitleBarIcon, 
          dialogViewModel => HandleFileExistsDialogResponseAsync(dialogViewModel, filePath, settingsData));
        
        // Show the dialog by setting the DialogViewModel property to an instance of DialogViewModel
        this.DialogViewModel = fileExistsdialogViewModel;
      }
      
      // Continuation callback. Will be invoked once the dialog closed. 
      // The parameter is the previously created FileExistsDialogViewmodel containing data set from the dialog.
      private async Task HandleFileExistsDialogResponseAsync(DialogViewModel dialogViewModel, string filePath, string settingsData)
      {
        if (dialogViewModel.DialogResult == DialogResult.Accepted)
        {
          // Example method
          await SaveFileAsync(filePath, settingsData);
        }
      }
      
      private DialogViewModel dialogViewModel;   
      public DialogViewModel DialogViewModel
      {
        get => this.dialogViewModel;
        set 
        { 
          this.dialogViewModel = value; 
          OnPropertyChanged();
        }
      }
    }
