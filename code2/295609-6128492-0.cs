    ColumnHeader columnHeader1=new ColumnHeader();
    columnHeader1.Text="Column1";
    this.listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
    ListViewItem item = new ListViewItem("1");
    this.listView1.Items.Add(item);
    this.listView1.View = View.Details;
