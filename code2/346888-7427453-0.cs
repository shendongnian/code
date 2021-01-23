    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == DataControlRowState.Alternate))
                {
                    Label groupID = (Label)e.Row.FindControl("idgroup");
                    LinkButton myLink = (LinkButton)e.Row.FindControl("groupLink");
                    myLink.Attributes.Add("rel", groupID.Text);
                }
            }
        }
