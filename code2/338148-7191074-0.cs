    productbindingsource.DataSource = productsbycount;
            productgridview.DataSource = productbindingsource;
            DataGridViewButtonColumn buttoncolumn = new DataGridViewButtonColumn();
            productgridview.Columns.Add(buttoncolumn);
            buttoncolumn.Text = "Buy";
            buttoncolumn.HeaderText = "Buy";
            buttoncolumn.UseColumnTextForButtonValue = true;
            buttoncolumn.Name = "btnbuy";
            productgridview.Columns[0].Visible = false;
