      if (openFile.ShowDialog() == DialogResult.OK) {
        DataTable dt = new DataTable();
        dt.Columns.Add("Tasks", typeof(string));
        dt.Columns.Add("Comparison Time", typeof(int));
        dt.Columns.Add("T (Period)", typeof(int));
        dt.Columns.Add("Deadline", typeof(int));
        var items = File.ReadLines(openFile.FileName).Select(line => line.Trim().Split(' '));
        foreach (var line in items) {
          dt.Rows.Add(line);
        }
        dataGridView1.DataSource = dt;
        dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
      }
