     protected void Page_Load(object sender, EventArgs e)
        {
          if (Session["User_ID"] == null)
           {
             Response.Redirect("~/Default.aspx");
           }
           else
           {
             UserName.Text = Session["Employee_Name"].ToString() + " (" + Session["User_ID"].ToString() + ")";
            }
         }
