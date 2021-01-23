    protected void Position()
    {
       JobPosition p = null;
       if (Session["PositionID"] == null)
        {
            p = new JobPosition();
        }
        else
        { 
            p = new JobPosition(Convert.ToInt32(Session["PositionID"]));
        }
        if (p != null)
        {
            p.positionTitle= pTitle.text;
            p.positionMission= pMission.text;
            p.positionDepartment= pDept.text;
            Session["PositionID"] = Convert.ToString(p.SaveDB()); 
        } 
    }
