        protected void GridView_PageIndexChanged(object sender, EventArgs e)
        {
    ...your code to handle anything after the page has changed
    
                        gv.DataSource = dt;
                        gv.DataSourceID = null;
                        gv.DataBind();
        
                        //reload any checkboxes that were session saved in the page
                        LoadPageState(gv);
                    }
                }
            }
        }
