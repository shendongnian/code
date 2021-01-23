    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Always bind the list to here, if needed
    
            if (Request.QueryString["selected"] != null)
            {
                int selected;
                if (int.TryParse(Request.QueryString["selected"], out selected))
                {   
                    RadioButtonList1.SelectedIndex = selected;
    
                }
            }
        }
    }
