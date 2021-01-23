            for (int i = 0; i < (DataTable)ViewState["CurrentTable"].Rows.Count; i++)
            {
                //extract the TextBox values
                TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                //TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                DropDownList box2 = (DropDownList)Gridview1.Rows[i].Cells[2].FindControl("ddldatatype");
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = i;
                drCurrentRow["Column1"] = box1.Text;
                drCurrentRow["Column2"] = box2.Text;
                //drCurrentRow["Column3"] = box3.Text;
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
            }
