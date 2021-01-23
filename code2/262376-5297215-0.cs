    public void Page_Load(object source, Event Args e)
    {
    
       if(Session["Something"] == "ShowDiv")
          AssignUniqueId.Visible = true;
        else
          AssignUniqueID.Visible = false;
    }
