    var query = new BoolQuery
    {
        Must = new QueryContainer[]
        {
            new NestedQuery
            {
                Path = "properties",
                Query = new BoolQuery()
                {
                    Must = new QueryContainer[]
                    {
                        new TermQuery()
                        {
                            Field = new Nest.Field("properties.source.keyword"),
                            Value = "Color"
                        },
                        new TermsQuery()
                        {
                            Field = new Nest.Field("properties.value.keyword"),
                            Terms = new[] { "green", "blue"}
                        }
                    }
                }
            },
            new NestedQuery
            {
                Path = "properties",
                Query = new BoolQuery()
                {
                    Must = new QueryContainer[]
                    {
                        new TermQuery()
                        {
                            Field = new Nest.Field("properties.source.keyword"),
                            Value = "Size"
                        },
                        new TermsQuery()
                        {
                            Field = new Nest.Field("properties.value.keyword"),
                            Terms = new[] {"2"}
                        }
                    }
                }
            }
        }
    };
