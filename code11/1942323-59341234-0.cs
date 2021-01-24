        private void grdTest_InitCustomEdit(object sender, Janus.Windows.GridEX.InitCustomEditEventArgs e)
        {
            if (e.Column.Key == "ColumnName")
            {
                cboTest.Visible = true;
                e.EditControl = cboTest;
            }
        }
        private void grdTest_EndCustomEdit(object sender, Janus.Windows.GridEX.EndCustomEditEventArgs e)
        {
           //this (dtTest) datatable is actually the datasource assigned for the grid
            dtTest.DefaultView.RowFilter = string.Empty;
            cboTest.Visible = false;
            string Filter = string.Empty;
            if (cboTest.CheckedItems != null)
            {
                foreach (GridEXRow row in cboTest.DropDownList.GetCheckedRows())
                {
                    if (Filter != string.Empty)
                        Filter += " OR ColumnName = '";
                    else Filter = "( ColumnName = '";
                    Filter += row.Cells[2].Value;
                    Filter += "'";
                }
                Filter += " )";
            }
            dtTest.DefaultView.RowFilter = Filter;
            grdTest.DataSource = dtTest.DefaultView;
        }
        private void grdTest_ClearFilterButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (e.Column.Key == "ColumnName")
                cboTest.CheckAll();
            grdTest_EndCustomEdit(null, null);
        }
