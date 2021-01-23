    protected void Position()
    {
        JobPosition p;
        if (Session["PositionID"] == null)
        {
            p = new JobPosition();
        }
        else
        { 
            p = new JobPosition(Convert.ToInt32(Session["PositionID"]));
        }
        p.positionTitle= pTitle.text;
        p.positionMission= pMission.text;
        p.positionDepartment= pDept.text;
        Session["PositionID"] = Convert.ToString(p.SaveDB());   
    }
