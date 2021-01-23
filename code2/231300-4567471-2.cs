    ListView1.ItemActivate += ListView1_ItemActivate;
    
    private void ListView1_ItemActivate(Object sender, EventArgs e)
    {
      if(ListView1.SelectedItems.Count > 0)
      {
        this.form2Instance.ContentsTextBox.Text = File.ReadAllText(this.rootFilesPath + @"\" + ListView1.SelectedItems.Last().Text));
      }
    }
