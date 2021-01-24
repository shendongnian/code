    private void Export()
    {
      // Do UI check first
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "Excel Documents (*.xls)|*.xls";
      sfd.FileName = "Export.xls";
        
      // If failed , early out ( early out is a good practice, you may google for it )
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      ProgressWindow prg = new ProgressWindow();
      prg.Show();
      // Do your copy and export code below, you may use
      
      // After finished, close your progress window
      prg.Close();
    }
