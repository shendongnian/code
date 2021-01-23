    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
      try {
        string mailtoLink = "mailto:"+listView1.SelectedItems[0].SubItems[email_Column].Text;
        System.Diagnostics.Process.Start(mailtoLink);
      } catch(Win32Exception ex) {
        MessageBox.Show("An error has occured: "+ ex.Message);
      }
    }
