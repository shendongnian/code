    lv.ItemSelectionChanged += lv_ItemSelectionChanged;
    
    private void lv_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if(e.IsSelected)
      {
        if(e.Item.Tag == null)
        {
          var form = new Form2();
          // init Form2 here
          form.Parent = this.panel1;
          e.Item.Tag = form;
        }
        (e.Item as Form2).BringToFront();
      }
    }
