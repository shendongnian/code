    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) {
      if (e.TabPage.Name == tabPage2.Name) {
        if (tabPage2.Controls.Count == 0) {
          Form f = new Form();
          f.TopLevel = false;
          f.FormBorderStyle = FormBorderStyle.None;
          f.BackColor = Color.Red;
          f.Dock = DockStyle.Fill;
          tabPage2.Controls.Add(f);
          f.Show();
        }
      }
    }
