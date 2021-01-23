    Page_Load(Object sender, EventArgs e)
    {
        if (!this.IsPostback)
        {
            int membershipgen;        
    
            if (int.TryParse(Request.QueryString["membershipgen"], out membershipgen)
            {
                //Get the data (replace DataAccess with the name of your data access class).
                //Also, you probably want to change GetMembers so it returns the data.
                DataTable table = DataAccess.GetMembers(membershipgen);
                 
                //TODO: Display the results
            }
        }
        else
        {
            //Display an error
        }
    }
