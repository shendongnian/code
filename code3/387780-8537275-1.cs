        MyGrid.AutoGenerateColumns = false;
        string selectClause = CreateSelectClauseWithProperty(typeof(User),
                new ExtraProperty[] { 
                        new ExtraProperty() 
                        { Name = "FullName", Expression = "FirstName + \" \" + LastName" }
                    }
                    );
        IQueryable<User> list = GetAllUsers();
        var query = list.Select( selectClause );
        MyGrid.DataSource =  query;
        MyGrid.DataBind();
