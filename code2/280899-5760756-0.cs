        protected void JqGrid_Requesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        { 
            if (Session["Cmd"] != null)
            {
                SqlDataSource1.SelectCommand = Session["Cmd"] as string; 
            }
        }
