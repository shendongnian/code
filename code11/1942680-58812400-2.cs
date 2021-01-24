    private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
    {
      var result = MessageBox.Show(this,
                                   "Are you sure you want to close the Application?",
                                   "Exit",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) );
      if ( result != DialogResult.Yes )
      {
        e.Cancel = true;
      }
    }
