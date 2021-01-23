    if (!IsPostBack)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
           membergridview1.Columns.Add(column);
            column.FlatStyle = FlatStyle.Standard;
            column.DefaultCellStyle.BackColor = Color.Green;
            column.Text = "ADD";
            column.HeaderText = "Add";
            column.UseColumnTextForButtonValue = true;
            column.Name = "btnadd";
        }
