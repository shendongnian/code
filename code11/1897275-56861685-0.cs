    using (GasMarketerDBEntities context = new GasMarketerDBEntities())
    {
        DateTime date;
        var query = context.Table.AsQueryable;
        if (!string.IsNullOrEmpty(tbName.Text))
            results = results.Where(x => x.Name == tbName.Text);
        if (!string.IsNullOrEmpty(tbType.Text))
            results = results.Where(x => x.Type == tbType.Text);
        if (!string.IsNullOrEmpty(tbFrom.Text) && DateTime.TryParse(tbFrom.Text, out date))
            results = results.Where(x => x.Date >= date);
        if (!string.IsNullOrEmpty(tbTo.Text) && DateTime.TryParse(tbTo.Text, out date))
            results = results.Where(x => x.Date <= date);
        if (myGridView.EditIndex != -1)
            myGridView.EditIndex = -1;
        if (ViewState["SortDirection"].ToString() == "ASC")
        {
            switch (ViewState["SortBy"].ToString())
             {
                 case "Date":
                     results = results.OrderBy(x => x.Date);
                     break;
                 case "Name":
                     results = results.OrderBy(x => x.Name);
                     break;
                 case "Type":
                     results = results.OrderBy(x => x.Type);
                     break;
             }
         }
         else
         {
             switch (ViewState["SortBy"].ToString())
             {
                 case "Date":
                     results = results.OrderByDescending(x => x.Date);
                     break;
                 case "Name":
                     results = results.OrderByDescending(x => x.Name);
                     break;
                 case "Type":
                     results = results.OrderByDescending(x => x.Type);
                     break;
            }
        }
        var results = query.ToList(); // Single ToList call to materialize.
        gvNominations.DataSource = results;
        gvNominations.DataBind();
        // Session["DataSource"] = gvNominations.DataSource; Don't persist these entities
    }
