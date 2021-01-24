            var mapResponse = client.Map<SearchCompletion>(m => m
                .Index("index")
                .AutoMap()
                .Properties(props => props
                    .Completion(c => c
                        .Name(n => n.suggest)
                        .Contexts(context => context
                            .Category(cat => cat.Name("isActive"))
                        )
                    )
                )
            );
			
			// let's create data
            var r1 = client.Index(new SearchCompletion
            {
                search = "plate", suggest = new CompletionField
                {
                    Input = new[] {"plate", "dish"}, // this one has two suggestions
                    Contexts = new Dictionary<string, IEnumerable<string>>
                    {
                        {
                            "isActive",
                            new[] {"yes"} // isActive is 'yes'
                        }
                    }
                }
            }, d => d.Index("index"));
            var r2 = client.Index(new SearchCompletion
            {
                search = "fork",
                suggest = new CompletionField
                {
                    Input = new[] { "fork", "dis_example" }, // this has two suggestions
                    Contexts = new Dictionary<string, IEnumerable<string>>
                    {
                        {
                            "isActive",
                            new[] {"no"} // isActive is 'no'
                        }
                    }
                }
            }, d => d.Index("index"));
            var r3 = client.Index(new SearchCompletion
            {
                search = "spoon",
                suggest = new CompletionField
                {
                    Input = new[] { "spoon" },
                    Contexts = new Dictionary<string, IEnumerable<string>>
                    {
                        {
                            "isActive",
                            new[] {"yes"} // isActive is 'yes'
                        }
                    }
                }
            }, d => d.Index("index"));
			// Let's search for the dish using 'dis' and limiting it to IsActive == 'yes'
            var searchResponse = client.Search<SearchCompletion>(s => s.Index("index").Suggest(su => su
                .Completion("search", cs => cs
                    .Field(f => f.suggest)
                    .Contexts(con => con.Context("isActive", aa => aa.Context("yes")))
                    .Prefix("dis")
                    .Size(10)
                )
            ));
