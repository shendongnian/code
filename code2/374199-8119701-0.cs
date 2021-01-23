    [STAThread]
      static void Main() 
      {
        Application.Run(new PrintPreviewDialog());
      }
    
      private void btnOpenFile_Click(object sender, System.EventArgs e)
      {
        openFileDialog.InitialDirectory = @"c:\";
        openFileDialog.Filter = "Text files (*.txt)|*.txt|" +
                "All files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;              //  1 based index
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          StreamReader reader = new StreamReader(openFileDialog.FileName);
          try
          {
            strFileName = openFileDialog.FileName;
            txtFile.Text = reader.ReadToEnd();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
            return;
          }
          finally
          {
            reader.Close();
          }
        }
      }
    
      private void btnSaveFile_Click(object sender, System.EventArgs e)
      {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.InitialDirectory = @"c:\";
        sfd.Filter = "Text files (*.txt)|*.txt|" +
                "All files (*.*)|*.*";
        sfd.FilterIndex = 1;              //  1 based index
    
        if (strFileName != null)
          sfd.FileName = strFileName;
        else
          sfd.FileName = "*.txt";
        
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          StreamWriter writer = new StreamWriter(strFileName,false);
          try
          {
            strFileName = sfd.FileName;
            writer.Write(txtFile.Text);
          }
          catch(Exception ex)
          {
            MessageBox.Show(ex.Message);
            return;
          }
          finally
          {
            writer.Close();
          }
        }
      }
    
