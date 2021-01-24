    private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( ThereAreUnsavedChanges )
        switch ( new SaveDataQueryBox().ShowDialog() )
        {
          case DialogResult.Yes:
            DoSave();
            break;
          case DialogResult.No:
            break;
          case DialogResult.Cancel:
            e.Cancel = true;
            break;
        }
    }
