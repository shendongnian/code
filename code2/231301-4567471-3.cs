    ListView1.ItemActivate += ListView1_ItemActivate;
    private void ListView1_ItemActivate(Object sender, EventArgs e)
    {
      if(ListView1.SelectedItems.Count > 0)
      {
        var item = ListView1.SelectedItems.Last();
        if(item.Tag == null)
          item.Tag = File.ReadAllText(this.rootFilesPath + @"\" + item.Text);
        this.form2Instance.ContentsTextBox.Text = (string) item.Tag;
      }
    }
