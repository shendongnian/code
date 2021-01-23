            DataGridViewComboBoxColumn cbol = new DataGridViewComboBoxColumn();
            cbol.HeaderText = "Actions";
            cbol.Items.Add("Print Job Card");
            cbol.Items.Add("Print Invoice");
            cbol.Items.Add("Close Job Card");
            cbol.Name = "bcolumn";
            dataGridView1.Columns.Add(cbol);
