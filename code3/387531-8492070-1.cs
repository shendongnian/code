    private void saveOnlyPlaylistToolStripMenuItem_Click(object sender, EventArgs e) {
      StackTrace st = null;
      string message = null;
      try {
        MainMenuClick(sender, e);
      } catch (Exception ex) {
        st = new StackTrace();
        message = ex.Message;
      }
      if (st != null) {
        try {
          string methodName = st.GetFrame(1).GetMethod().Name;
          Logger.LogToFile("Failure in " + methodName + ": " + ex.Message);
        } catch (Exception ex) {
          MessageBox.Show(ex.Message);
        }
      }
    }
