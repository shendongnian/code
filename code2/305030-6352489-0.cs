    private void TestUniqueSelection(object sender, System.EventArgs e)
    {
          var controls = new List<System.Windows.Forms.ComboBox>();
          controls.Add(...); // <-- Add all of your controls here.
    
          ComboBox changedBox = (ComboBox) sender;
    
          if (controls
               .Where(a => a != changedBox && a.SelectedItem == changedBox.SelectedItem)
               .Count() > 0)
               MessageBox.Show("Selected Option has already been chosen");
    }
