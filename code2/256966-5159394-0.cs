    var items = mongoCollection.FindAs<Type>(Query.EQ("someProperty", "someValue"))
               .SetSortOrder("orderField").SetLimit(100).Skip(10);
    
    telerikGrid.DataSource = items;
    telerikGrid.DataBind();
    ....
    
    telerikGrid_OnItemDelete(object sender, SomeEventArgs e)
    {
       var id = e. //get parameter from args
       ..
       mongoCollection.Remove(Query.EQ("_id", id));
    }
