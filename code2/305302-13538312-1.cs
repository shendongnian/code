    ...
    MyDataGridView.DataSource = MyDatatable;
    MyDatatable.RowFilter = "[Active] = 1";
    MyDataGridView.DataSource = MyDatatable;
    MyDataGridView.Columns["NewCol"].Visible = false;   // YAY!! Now it hides
    MyDataGridView.Columns["Changed"].Visible = false;
    MyDataGridView.Columns["Active"].Visible = false;
    ...
