        protected void gridview1_DataBound(object sender, EventArgs e)
        {
            Boolean hasData = false;
            for (int col = 0; col < gridview1.HeaderRow.Cells.Count; col++)
            {
                for (int row = 0; row < gridview1.Rows.Count; row++)
                {
                    if (!String.IsNullOrEmpty(gridview1.Rows[row].Cells[col].Text)
                        && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(gridview1.Rows[row].Cells[col].Text).Trim()))
                    {
                        hasData = true;
                        break;
                    }
                }
                if (!hasData)
                {
                    gridview1.HeaderRow.Cells[col].Visible = false;
                    for (int hiddenrows = 0; hiddenrows < gridview1.Rows.Count; hiddenrows++)
                    {
                        gridview1.Rows[hiddenrows].Cells[col].Visible = false;
                    }
                }
                hasData = false;
            }
  
        }
