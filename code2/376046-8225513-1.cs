     protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session.Abandon();
                Session.RemoveAll();
                Session.Clear();
    
                if (Session["hr"] == null && Session["EMPLOYEEID"]==null)
                {
                    Response.Redirect("~/loginAcc.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["hr"] == null && Session["EMPLOYEEID"] == null)
            {
                Response.Redirect("~/loginAcc.aspx");
            }
        }
