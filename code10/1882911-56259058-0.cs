    List<UpdateItem> updateList = initialDocuments.Select(d =>
                    new UpdateItem(
                        d.id,
                        d.AccountNumber,
                        new List<UpdateOperation> {
                            new SetUpdateOperation<string>(
                                "NewSimpleProperty", 
                                "New Property Value"),
                            new SetUpdateOperation<dynamic>(
                                "NewComplexProperty", 
                                new {
                                    prop1 = "Hello",
                                    prop2 = "World!"
                                }),
                            new UnsetUpdateOperation(nameof(FakeOrder.DocumentIndex)),
                        }))
                    .ToList();
    
                var updateSetResult = BulkUpdatetDocuments(_database, _collection, updateList).GetAwaiter().GetResult();
