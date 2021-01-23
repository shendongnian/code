    protected Boolean CanClose(Boolean CanIt)
    {
       if(MessageBox.Show("Wanna close?", "Cancel Installer", MessageBoxButtons.YesNo,       MessageBoxIcon.Question).ShowDialog() == DialogResult.Yes)
       {
          // Yes, they want to close.
          CanIt = true;
       }
       else
       {
         // No, they don't want to close.
         CanIt = false;
       }
    
       return CanIt;
    }
    
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if(CanClose(false) == true)
        {
           this.Dispose(true);
        }
        else
        {
           e.Cancel = true;
        }
    }
