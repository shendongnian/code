    protected void imgbtnUp_Click(object sender, ImageClickEventArgs e)
    {   
        DataTable dt = new DataTable();
        DataTable dtnew = new DataTable();    
        if (gvMileStone.Rows.Count > 0)
        {
            int index = gvMileStone.SelectedIndex;
            if (index == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), Guid.NewGuid().ToString(), "window.alert('You cannot move the record up!')", true);
                return;
            }
            else
            {
                dt = (DataTable)ViewState["Template"];//dt is the DataTable I mentioned above
                int value = Convert.ToInt32(dt.Rows[index]["SeqNbr"].ToString());
                dt.Rows[index]["SeqNbr"] = Convert.ToInt32(index) - 1;
                dt.Rows[index - 1]["SeqNbr"] = value;// Convert.ToInt32(index);
                dt.DefaultView.Sort = "SeqNbr";
                dt.AcceptChanges();
                dtnew = dt.Copy();
                gvMileStone.DataSource = dt;
                gvMileStone.DataBind();
                dt.AcceptChanges();
                for (int i = 0; i <= gvMileStone.Rows.Count - 1; i++)
                {
                    dtnew.Rows[i]["MileStoneID"] = Convert.ToInt32(((Label)gvMileStone.Rows[i].FindControl("lblMileStoneID")).Text);
                    dtnew.Rows[i]["MileStoneName"] = gvMileStone.Rows[i].Cells[1].Text;
                    dtnew.Rows[i]["Percentage"] = Convert.ToDecimal(((TextBox)gvMileStone.Rows[i].FindControl("txtPercentage")).Text);
                    dtnew.Rows[i]["SeqNbr"] = Convert.ToInt32(((Label)gvMileStone.Rows[i].FindControl("lblSeqNbr")).Text);
                }
                ViewState["Template"] = dtnew;
            }
       }
       else
       {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), Guid.NewGuid().ToString(), "window.alert('There is no rows to move!')", true);
            return;
       }
    }
