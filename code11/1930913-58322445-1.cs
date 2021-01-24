    string filename = openFileDialog1.FileName;
    var lines = File.ReadAllLines(filename);
    textBox1.Text = string.Join(Environment.NewLine, lines);
    foreach ( string line in lines )
    {
      var items = line.Split(new char[0]);
      if ( items.Length > 0 )
      {
        var item = new ListViewItem(items[0]);
        if ( items.Length > 1 )
          item.SubItems.Add(items[1]);
        listView1.Items.Add(item);
      }
    }
