    ...
    MyDataGridView.DataSource = MyDatatable;
    MyDataGridView.Columns["NewCol"].Visible = false;   // doesn't hide (col 0)
    MyDataGridView.Columns[0].Visible = false;          // also doesn't hide col 0
    MyDataGridView.Columns["Changed"].Visible = false;
    MyDataGridView.Columns["Active"].Visible = false;
    MyDatatable.RowFilter = "[Active] = 1";
    ...
