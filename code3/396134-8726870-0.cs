    SPList list = // some list;
    SPQuery query = new SPQuery();
    query.RowLimit = 1;
    query.Query = String.Format("<OrderBy><FieldRef ID='{0}' /></OrderBy>", 
                                  SPBuiltInFieldId.Created);
    return list.GetItems(query).Cast<SPListItem>().FirstOrDefault();
