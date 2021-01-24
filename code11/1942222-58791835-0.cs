    private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( ThereAreUnsavedData )
        switch ( MessageBox.Show("Message", 
                                 Text,
                                 MessageBoxButtons.YesNoCancel,
                                 MessageBoxIcon.Question) )
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
