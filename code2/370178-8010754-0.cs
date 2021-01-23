    struct LogItem {
      public string Text;
      public Colour ItemColour
    }
    private void Log(string status) { 
      LogItem item = new LogItem();
      item.Text = "Wibble";
      item.ItemColour = Colours.Red;
      lbxLogText.Items.Add(item); 
    }
    private void lbxLogText_DrawItem(object sender, DrawItemEventArgs e) {   
      LogItem item = lbxLogText.Items[e.Index];
      e.DrawBackground();   
      e.DrawFocusRectangle();   
      e.Graphics.DrawString(item.Text,    
        new Font(FontFamily.GenericSansSerif, 8),   
        new SolidBrush(item.Color), e.Bounds);   
    }  
