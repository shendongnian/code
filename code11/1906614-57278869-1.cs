    void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // If we are posting back, AND the inducing postback control is *NOT* 
            // the owner dropdown, reload the specimen type
            if (Request.Form["__EVENTTARGET"] != ddlOwner.ClientID)
            {
                loadOtherSpecimenType();
            }else
            {
               // other code here //
            }
       } 
       else
       {
          // code for non-postback load here
       }
    }     
       
        
