    protected void Page_Load(object sender, EventArgs e)
    {    
        int selected;
        if (int.TryParse(Request.QueryString["selected"], out selected))
            RadioButtonList1.SelectedIndex = selected;
            RadioButtonList1.DataBind();         
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRedirect;
        strRedirect = "frm_Articles.aspx?selected=" + RadioButtonList1.SelectedIndex;
        Response.Redirect(strRedirect);
    }
