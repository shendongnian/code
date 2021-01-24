    private ContextMenuStrip CreateContextMenuStrip()
    {
      var result = new ContextMenuStrip();
      if ( extension.Equals("sty") || extension.Equals("st2") || extension.Equals("sst") )
      {
        var item = c.Items.Add("Style files (c/u)");
        item.Tag = "style";
        item.Click += CheckSelectedType;
     }
      else
      if ( extension.Equals("txt") )
      {
        var item = c.Items.Add("Text files (c/u)");
        item.Tag = "text";
        item.Click += CheckSelectedType;
      }
      return result;
    }
    private void CheckSelectedType(object sender, EventArgs e)
    {
      switch ( (string)((ToolStripItem)sender).Tag )
      {
        case "style":
          // ...
          break;
        case "text":
          // ...
          break;
      }
    }
