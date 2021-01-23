            protected void lnkEdit_Click(object sender, EventArgs e)
            {
                try
                {
                    LinkButton lb = new LinkButton();
                    lb = (LinkButton)sender;
                    Control control = lb.NamingContainer;
                    GridDataItem gridDataItem = (GridDataItem)control;
    
                    int itemId= Convert.ToInt32(gridDataItem["dtgColItemId"].Text);
    
                    Response.Redirect("/yourpage.aspx?id=" + itemId);
                }
                catch
                {
    
                }
            }
