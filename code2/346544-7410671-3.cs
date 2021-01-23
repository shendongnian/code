    var contacts = service.RetrieveMultiple(new QueryExpression
                                                {
                                                    EntityName = "contact",
                                                    ColumnSet = new ColumnSet("firstname")
                                                })
        .Entities
        .Select(item => item.ToEntity<Contact>());
