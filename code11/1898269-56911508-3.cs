    //Add the columns to context menu strip
    foreach (DataGridViewColumn c in dataGridView1.Columns)
    {
        var item = (ToolStripMenuItem)contextMenuStrip1.Items.Add(c.HeaderText);
        item.Tag = c.Name;
        item.Checked = c.Visible;
        item.CheckOnClick = true;
        //Hanlde CheckStateChanged event of context menu strip items
        item.CheckStateChanged += (obj, args) =>
        {
            var i = (ToolStripMenuItem)obj;
            dataGridView1.Columns[(string)i.Tag].Visible = i.Checked;
        };
    }
    //Show context menu strip on right click on data grid veiw header
    dataGridView1.CellMouseClick += (obj, args) =>
    {
        if (args.RowIndex == -1 && args.Button == MouseButtons.Right)
            contextMenuStrip1.Show(Cursor.Position);
    };
