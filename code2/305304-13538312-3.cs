    ...
    MyDataGridView.DataSource = MyDatatable;
    MyDatatable.RowFilter = "[Active] = 1";
    MyDataGridView.Columns["NewCol"].Visible = false;   // YAY!! Now it hides
    // MyDataGridView.Columns[0].Visible = false;       <<<< and this works too
    MyDataGridView.Columns["Changed"].Visible = false;
    MyDataGridView.Columns["Active"].Visible = false;
    ...
