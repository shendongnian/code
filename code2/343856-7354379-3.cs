    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        String query = "%%";
            
        if (PersonnelSearchTextBox.Text != String.Empty)
        {
            query = "%" + PersonnelSearchTextBox.Text + "%";
        }
        var personnel = (from i in context.Personnel
                             where SqlMethods.Like(i.PersonnelName, query) ||
                                     SqlMethods.Like(i.PersonnelOffice, query) ||
                                     SqlMethods.Like(i.Username, query) ||
                                     SqlMethods.Like(i.Department, query)
                             select new
                             {
                                 ID = i.ID,
                                 PersonnelName = i.PersonnelName,
                                 PersonnelOffice = i.PersonnelOffice,
                                 Department = i.Department,
                                 Username = i.Username
                             });
                             
        e.Result = personnel;
    }
