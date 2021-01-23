    class MyForm : Form
    {
      public void OnButtonClick()
      {
        if(!isSubDialogOpen)
        {
          isSubDialogOpen = true;
          ShowSubDialog();
        }
      }
    
      private void OnSubDialogClose()
      {
        isSubDialogOpen = false;
      }
    
      private void ShowSubDialog()
      {
        SubDialog subDialog = new SubDialog(this);
        subDialog.OnClose += OnSubDialogClose;
        subDialog.Show();
      }
    
      private bool isSubDialogOpen;
    }
    
    class SubDialog : Form
    {
      // ...
    }
