    var contacts = service.RetrieveMultiple<Contact>(new QueryExpression
                                                            {
                                                                EntityName = "contact",
                                                                ColumnSet = new ColumnSet("firstname")
                                                            });
