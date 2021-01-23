    var AllPeople = 
        (from r in CompanyDataTable.AsEnumerable()
        select new
        {
            FirstName = r.Field<string>("FirstName"),
            LastName = r.Field<string>("LastName"),
            Gender = r.Field<string>("Gender"),
            Age = r.Field<double>("Age"),
            City = r.Field<string>("City"),
            State = r.Field<string>("State"),
            Cagegory = r.Field<string>("CategoryGroup"),
        }).ToList();
