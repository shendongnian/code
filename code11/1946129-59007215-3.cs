    private async void btnAdd_Click(object sender, EventArgs e)
    {
            int[] selectedRows = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                DataRow rowGridView1 = (gridView1.GetRow(selectedRows[i]) as DataRowView).Row;
                for (int j = 0; j < gridView3.RowCount; j++)
                {
                    if (rowGridView1["BS"].ToString() == gridView3.GetRowCellValue(j, "ProjectN").ToString() &&
                        rowGridView1["Repère"].ToString() == gridView3.GetRowCellValue(j, "Parts").ToString())
                    {
                        DataRow row = dt.NewRow();
                        row[0] = rowGridView1["BS"];
                        row[1] = gridView3.GetRowCellValue(j, "Parts");
                        row[2] = gridView3.GetRowCellValue(j, "Profile");
                        row[3] = rowGridView1["Quantité"];
    
                        dt.Rows.Add(row);
    		    dt.AcceptChanges();
                    }
                }
           }
           
           gridView1.Datasource=dt;
           grid.DataBind();
    }
