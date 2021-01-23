     protected void gvAgentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAgentList.SelectedRow;
            Response.Redirect("~/FrontEnd/Registration.aspx? EntityID=" + row.Cells[0].Text);
        }
