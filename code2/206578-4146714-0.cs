    using (MyDataContext context = CreateDataContext())
    {
        // Set the load options for the query (these tell LINQ that the
        // DataNode object will have an associated DataObject object just
        // as before).
        context.LoadOptions = StaticLoadOptions;
        // Run a plain old SQL query on our context.  LINQ will use the
        // results to populate the node object (including its DataObject
        // property, thanks to the load options).
        DataNode node = context.ExecuteQuery<DataNode>(
            "SELECT * FROM Node INNER JOIN Object " +
            "ON Node.ObjectId = Object.ObjectId " +
            "WHERE ObjectId = @p0",
            objectId).FirstOrDefault();
        //...
    }
