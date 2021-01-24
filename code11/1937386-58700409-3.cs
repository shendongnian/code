        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["TimeSelected"] != null)
            {
                MovieTime.Text = Session["TimeSelected"].ToString();
            }
                else
    {
    //user did not select a time
    //possibly redirect them back to the showtimes page.
      response.redirect("/previousepage.aspx");
    }
        }
