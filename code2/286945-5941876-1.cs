     // Create the QueryExpression object.
     var query = new QueryExpression();
     // Set the properties of the QueryExpression object.
     query.EntityName = EntityName.contact.ToString();
     query.ColumnSet = new AllColumns();
     // Retrieve the contacts.
     BusinessEntityCollection contacts = service.RetrieveMultiple(query);
