    var graphServiceClient = GraphClientFactory.GetGraphServiceClient(config.ClientId, config.Authority, config.Scopes);
                if (graphServiceClient != null)
                {                    
                    List<ColumnDefinition> listOfCols = new List<ColumnDefinition>() {
                        new ColumnDefinition
                            {
                                Name = "Author",
                                Text = new TextColumn
                                {
                                }
                            },
                            new ColumnDefinition
                            {
                                Name = "PageCount",
                                Number = new NumberColumn
                                {
                                }
                            }
                    };
                    ListColumnsCollectionPage columns = new ListColumnsCollectionPage();
                    foreach (ColumnDefinition item in listOfCols)
                    {
                        columns.Add(item);
                    }
                    List list = new List
                    {
                        DisplayName = "TestGraph",
                        Columns = columns,
                        ListInfo = new ListInfo
                        {
                            Template = "genericList"
                        }
                    };
                    await graphServiceClient.Sites["tenant.sharepoint.com,x-b669-4537-b0f5-x,x-e306-407b-b1a2-x"].Lists
                        .Request()
                        .AddAsync(list);
                    Console.WriteLine("----");
                }
