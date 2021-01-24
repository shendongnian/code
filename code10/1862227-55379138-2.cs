     if (ComboBox_LoginAs.SelectedIndex == 0)
      {
         this.Hide();
         Main_Form mainSystem = new Main_Form();
         mainSystem.Show();
      }
      else if (ComboBox_LoginAs.SelectedIndex == 1)
      {
         this.Hide();
         Main_Form mainSystem = new Main_Form();
         mainSystem.Show();
         Main_Form.GetMainForm_Obj.eMPLOYEESToolStripMenuItem.Enabled = false;
       }
