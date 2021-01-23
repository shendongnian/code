    protected void Page_Load(object sender, EventArgs e)
    {
    
          if (Request["uid"] != null)
              userID = Int32.Parse(Request["uid"]);
    
          
        DisplayStatus();
     }
    
    private void DisplayStatus()
    {
          UserDAO ud = new UserDAO();
          tblUser u = ud.GetUser(userID);
          AccountStatus.Text = (((Boolean)u.ActiveOrNot) ? "Active" : "Inactive") + "<br />";
    }
    
     protected void btnActivate_OnClick(object sender, EventArgs e)
     {
          UserDAO udao = new UserDAO();
          int userBeingEdited = -1;
    
          if (Request["uid"] != null)
          {
              userBeingEdited = Int32.Parse(Request["uid"]);
          }
          if (udao.ActivateUser(userBeingEdited))
          {
              DisplayError("This user has been activated.", true);
          }
    
          DisplayStatus();
     }
