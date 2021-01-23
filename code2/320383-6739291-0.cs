    private subform _subForm1 = null;
    private subform _subForm2 = null;
    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (e.TabPage.Name == tabPage1.Name)
      {
        if (_subForm1 == null)
        {
          _subForm1 = new subform();
          tabPage1.Controls.Add(_subForm1);
          _subForm1.Show();
        }
      }
      else if (e.TabPage.Name == tabPage2.Name)
      {
        if (_subForm2 == null)
        {
          _subForm2 = new subform();
          tabPage2.Controls.Add(_subForm2);
          _subForm2.Show();
        }
      }
