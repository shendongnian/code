        void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
                {
                    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
                    {
                        GridView gv = e.Item.FindControl("GridView1") as GridView;
                        if (gv != null )
                        {
    
                            gv.DataBind();
                            if(ddlMyList.SelectedText != "ALL")
                            {
                            if (gv.Columns.Count > 0)
                                gv.Columns[0].Visible = false;
                            else
                            {
                                gv.HeaderRow.Cells[0].Visible = false;
                                foreach (GridViewRow gvr in gv.Rows)
                                {
                                    gvr.Cells[0].Visible = false;
                                }
                            }
                         }
        
                        }
                    }
                }
