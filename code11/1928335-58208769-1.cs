    private ContextMenuStrip CreateContextMenuStrip(string extension)
    {
      var result = new ContextMenuStrip();
      if ( extension.Equals("sty") || extension.Equals("st2") || extension.Equals("sst") )
      {
        var item = result.Items.Add("Style files (c/u)");
        item.Tag = "style";
        item.Click += ContextMenuItem_Click;
      }
      else
      if ( extension.Equals("txt") )
      {
        var item = result.Items.Add("Text files (c/u)");
        item.Tag = "text";
        item.Click += ContextMenuItem_Click;
      }
      return result;
    }
    private void ContextMenuItem_Click(object sender, EventArgs e)
    {
      switch ( (string)( (ToolStripItem)sender ).Tag )
      {
        case "style":
          // ...
          break;
        case "text":
          // ...
          break;
      }
    }
