    private void ExportGridToCSV()
            {            
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Employee.csv");
                Response.Charset = "";
                Response.ContentType = "application/text";
                GridEmployee.AllowPaging = false;
                GridEmployee.DataBind();
        
                StringBuilder columnbind = new StringBuilder();
                for (int k = 0; k < GridEmployee.Columns.Count; k++)
                {
        
                    columnbind.Append(GridEmployee.Columns[k].HeaderText + ',');
                }
        
                columnbind.Append("\r\n");
                for (int i = 0; i < GridEmployee.Rows.Count; i++)
                {
                    for (int k = 0; k < GridEmployee.Columns.Count; k++)
                    {
        
                        columnbind.Append(GridEmployee.Rows[i].Cells[k].Text + ',');
                    }
        
                    columnbind.Append("\r\n");
                }
                Response.Output.Write(columnbind.ToString());
                Response.Flush();
                Response.End();
        
            }
