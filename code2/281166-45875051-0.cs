     protected void OnSelectedIndexChanged(object sender, EventArgs e)
                {        
                    foreach (GridViewRow row in GridVIew1.Rows)
                    {
                        if (row.RowIndex == GridVIew1.SelectedIndex)
                        {
                            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                            row.ToolTip = string.Empty;
                        }
                        else
                        {
                            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            row.ToolTip = "Click to select this row.";
                        }
                    }
                    //suppose your index is in cell[0]//
                    Session["Index"] = GridVIew1.SelectedRow.Cells[0].Text;
    }
