            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            productgridview.Columns.Add(column);
            column.FlatStyle = FlatStyle.System;
            column.DefaultCellStyle.ForeColor = Color.ForestGreen;
            column.DefaultCellStyle.Padding = new Padding(10, 48, 10, 48);
            column.Text = "Buy";
            column.HeaderText = "Buy";
            column.UseColumnTextForButtonValue = true;
            column.Name = "btnbuy";
