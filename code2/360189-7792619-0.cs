	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gvr = GridView1.Rows[e.NewEditIndex];
            Label lb = (Label)gvr.FindControl("lblCountry");
            
            GridView1.EditIndex = e.NewEditIndex;
            binddata();
            getselected(lb.Text);
        }
        private void getselected(string text)
        {
            GridViewRow gvr = GridView1.Rows[GridView1.EditIndex];
            
            DropDownList dr = (DropDownList)gvr.FindControl("ddlCCountry");
            dr.SelectedIndex = dr.Items.IndexOf(dr.Items.FindByText(text));
        }
