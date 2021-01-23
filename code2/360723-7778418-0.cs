        DatabaseDataContext db = new DatabaseDataContext();
        string WhereClause = string.Empty;
        if (!string.IsNullOrEmpty(Name))
            WhereClause += "Name.ToLower().Contains(\"" + Name.ToLower() + "\") AND ";
        if (!string.IsNullOrEmpty(State))
            WhereClause += "City.State.Name.ToLower().Contains(\"" + State.ToLower() + "\") AND ";
        if (!string.IsNullOrEmpty(County))
            WhereClause += "City.County.Name.ToLower().Contains(\"" + County.ToLower() + "\") AND ";
        if (!string.IsNullOrEmpty(City))
            WhereClause += "City.Name.ToLower().Contains(\"" + City.ToLower() + "\") AND ";
        if (WhereClause.EndsWith(" AND "))
            WhereClause = WhereClause.Remove(WhereClause.Length - 5);
        var query = db.Communities
                    .Where(WhereClause)
                    .OrderBy("Name");
