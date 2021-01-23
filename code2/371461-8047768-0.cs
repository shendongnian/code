    SPList list = ...; //your list;
    var query = new SPQuery();
    query.Query = "<OrderBy> <FieldRef Name="Your field"/> </OrderBy>" 
    //or
    query.Query = "<GroupBy> <FieldRef Name="Your field"/> </GroupBy>"
    var items = list.GetItems(query);
    foreach(var item in items)
    {
      //do your work
    }
