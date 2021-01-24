                var request = new GraphQLRequest
                {
                    Query = m_resource.Resource.GetString("CheckoutCreate"),
                    Variables = new
                    {
                        input = new
                        {
                            LineItems = lineItems // List<LineItem>
                        }
                };
