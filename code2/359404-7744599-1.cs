    protected void Position()
    {
       JobPosition p; // No need for null;
       if (Session["PositionID"] == null)
        {
            p = new JobPosition();
        }
        else
        { 
            p = new JobPosition(Convert.ToInt32(Session["PositionID"]));
        }
        
        // Don't need to check if p is null again here too
            p.positionTitle= pTitle.text;
            p.positionMission= pMission.text;
            p.positionDepartment= pDept.text;
            Session["PositionID"] = Convert.ToString(p.SaveDB()); 
   
    }
