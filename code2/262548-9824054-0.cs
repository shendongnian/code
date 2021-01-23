        private void LoadGrid()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("FieldNo");
            dtbl.Columns.Add("FieldValue");
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dtbl.NewRow();
                dr["FieldNo"] = i;
                dr["FieldValue"] = "Name " + i.ToString();
                dtbl.Rows.Add(dr);
            }
            dataGridView1.DataSource = dtbl;
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dtgv_ComboDataError);
        }
        private void dtgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    DataGridViewComboBoxCell dCmb = new DataGridViewComboBoxCell();
                    dCmb.Items.Add("Yes");
                    dCmb.Items.Add("No");
                    dCmb.Value = dCmb.Items[0];
                    dataGridView1["FieldValue", i] = dCmb;
                    ((DataGridViewComboBoxCell)dataGridView1["FieldValue", i]).DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
            }
        }
        void dtgv_ComboDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Nothing needed here
        } 
