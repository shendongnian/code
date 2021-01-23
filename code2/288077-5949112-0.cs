    UserControl user1 = (UserControl)this.NamingContainer.FindControl("[Object usercontrol]");
    DataList dl = (DataList)user1.FindControl("[Object datalist]");
    LinkButton lbtn = (LinkButton)dl.FindControl("[Object LinkButton]");
    
    // Check the validation
    if(lbtn != null)
    {
       // Do stuff
    }
    else
    {
       // Do other stuff
    }
