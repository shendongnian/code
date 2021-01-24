        private void cboTest_DropDown(object sender, EventArgs e)
        {
            int C = 1;
            DataRow DR;
            DataTable dtComboDS= new DataTable();
            dtComboDS.Columns.Add("ID", typeof(int));
            dtComboDS.Columns.Add("Name", typeof(string));
            var depts = (from x in dtTest.AsEnumerable() select x.Field<string>("ColumnName")).ToList();// dtTest is actually the datasource assigned for the GridEx
            foreach (var Row in depts.Distinct().ToList())
            {
                DR = dtComboDS.NewRow();
                DR["ID"] = C++;
                DR["Name"] = Row;
                dtComboDS.Rows.Add(DR);
            }
            cboTest.DropDownDataSource = dtComboDS;
        }
        private void cboTest_CloseUp(object sender, EventArgs e)
        {
            cboTest.Visible = false;
            grdTest.UpdateData();
        }
