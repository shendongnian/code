     protected void lnkTest_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((Control)sender).Parent.Parent;
            HiddenField hdnId = (HiddenField)gvr.FindControl("hdnId");
    
        if(Convert.ToString(hdnId.value)=="1")
        {
                Response.Redirect("frmTest1.aspx?Id=" + Convert.ToString(hdnId.Value), false);
        }
    
        else if(Convert.ToString(hdnId.value)=="2")
        {
            Response.Redirect("frmTest2.aspx?Id=" + Convert.ToString(hdnId.Value), false);
        }
        else
        {
            Response.Redirect("frmTest.aspx?Id=" + Convert.ToString(hdnId.Value), false);
        }
        }
