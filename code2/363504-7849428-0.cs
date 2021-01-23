    int i = 0;
    foreach (string name in names)
    {
        string paramname = "name" + (++i).ToString();
        var query = SessionHolder.Current
            .CreateQuery("select c.Name, c.Surname " +
                         "from Person as p " +
                         "where p.Name = :" + paramname + " or " +
                               "p.Name like ':" + paramname + "/%'")
            .SetParameter(paramname, name);
        multiQuery = multiQuery.Add(query);
    }
