        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            Session["ObjectParameterName"] = ddl.SelectedValue;
            ObjectDataSource1.Select();
        }
        protected void btnOne_Click(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            Session["ObjectParameterName"] = txt.Text;
            ObjectDataSource1.Select();
        }
