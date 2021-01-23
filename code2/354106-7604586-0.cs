        DatabaseDataContext db = new DatabaseDataContext();
        List<string> firstNames = new List<string>();
        //--- loop through names and build a where query
        string WhereClause = string.Empty;
        for (int i = 0; i < firstNames.Count(); i++)
        {
            string s = firstNames[i].ToLower();
            if (i != Communities.Length - 1)
                WhereClause += "FirstName.ToLower().Contains(\"" + s + "\") OR "; //--- first name is the field name in the db
            else
                WhereClause += "FirstName.ToLower().Contains(\"" + s + "\")";
        }
        //--- execute query and pass the dynamic where clause
        IQueryable contacts = db.Contacts
                              .Where(WhereClause)
                              .OrderBy("FirstName");
