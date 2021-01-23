    private void Buffer_Load(object sender, EventArgs e)
    {
      Logger.LogToFile("Entered Save Only Playlist.");
      DialogResult result = System.Windows.Forms.DialogResult.None;
      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.Filter = "Playlist (*.lpl)|*.lpl";
        try
        {
          // Add `this`
          result = sfd.ShowDialog(this);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Dialog problem: " + ex.Message);
        }
      }
      Logger.LogToFile("Result of Dialog: " + result.ToString());
      MessageBox.Show("Result of Dialog: " + result.ToString());
      // leave this line out - it would likely close your form:
      // DialogResult = result;
    }
