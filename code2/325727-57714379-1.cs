                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Academicprofileexcel.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                    //To Export all pages
                    Gridview1.AllowPaging = false;
                    this.getdetails();
    
                    Gridview1.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in Gridview1.HeaderRow.Cells)
                    {
                        cell.BackColor = Gridview1.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in Gridview1.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = Gridview1.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = Gridview1.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }
    
                    Gridview1.RenderControl(hw);
    
                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
