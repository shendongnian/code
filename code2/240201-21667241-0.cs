               HtmlTable tbl = (HtmlTable)pnl.FindControl("tblDataFeed");
                for (int ix = 0; ix <= tbl.Rows.Count - 1; ix++)
                {
                    HtmlTableRow row = tbl.Rows[ix];
                    tbl.Rows.Remove(row);
                }
