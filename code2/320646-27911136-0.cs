     void Page_Load( ... )
        {
            if (!Page.IsPostBack)
            {                
              Response.Redirect("Details.aspx?id=2");
            }
        }
