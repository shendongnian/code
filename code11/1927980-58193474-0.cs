    private void dataGridView1_DragDrop(object sender, DragEventArgs e)
    {
      dataGridView1.Columns.Add("Value", "Value");
      var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      foreach ( var file in files )
      {
        var lines = File.ReadAllLines(Path.GetFullPath(file));
        foreach ( string line in lines )
          dataGridView1.Rows.Add(line.TrimEnd(','));
      }
    }
    private void dataGridView1_DragEnter(object sender, DragEventArgs e)
    {
      if ( e.Data.GetDataPresent(DataFormats.FileDrop) )
        e.Effect = DragDropEffects.Move;
      else
        e.Effect = DragDropEffects.None;
    }
