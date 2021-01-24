    StringBuilder text = new StringBuilder();
    
    bool firstLine = true; 
    
    // We don't want redrawing after each ListViewItem adding
    listView1.BeginUpdate();
    
    try {
      // File.ReadLines is easier to manipulate with StreamReader
      // if you want just read lines
      foreach (string line in File.ReadLines(openFileDialog1.FileName)) {
        if (!firstLine)
          sb.AppendLine();
    
        sb.Append(line);
        firstLine = false; 
    
        // 3: We want at most 3 chunks (item, subitem and tail to throw away)
        string[] data = line.Split(new char[0], 3);
    
        ListViewItem item = new ListViewItem() {
          Text = data[0]
        };
    
        if (data.Length > 1)
          item.SubItems.Add(data[1]);
    
        listView1.Items.Add(item);
      }
    }
    finally {
      // The file has been scanned, items added; now we a ready to redraw the listView1   
      listView1.EndUpdate();
    }
    
    this.textBox1.Text = text.ToString();
