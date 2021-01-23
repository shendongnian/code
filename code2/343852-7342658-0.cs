    protected void Search_Submit(object sender, EventArgs e)
    {
        var personnel = (from i in context.Personnel
                         where SqlMethods.Like(i.PersonnelName, query)
                         where SqlMethods.Like(i.PersonnelOffice, query)
                         where SqlMethods.Like(i.Username, query)
                         where SqlMethods.Like(i.Department, query)
                         select new
                             {
                                 PersonnelName = i.PersonnelName,
                                 PersonnelOffice = i.PersonnelOffice,
                                 Username = i.Username,
                                 Department = i.Department
                              }).ToList();
        GridView1.DataSource = personnel;
        GridView1.DataBind();
    }
