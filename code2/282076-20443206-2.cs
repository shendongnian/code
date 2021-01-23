    ItemSearch search = new ItemSearch();
    search.AssociateTag = "YOUR ASSOCIATE TAG";
    search.AWSAccessKeyId = "YOUR AWS ACCESS KEY ID";           
    ItemSearchRequest req = new ItemSearchRequest();
    req.ResponseGroup = new string[] { "ItemAttributes" };
    req.SearchIndex = "Books";
    req.Author = "Lansdale";
    req.Availability = ItemSearchRequestAvailability.Available;
    search.Request = new ItemSearchRequest[]{req};
        
    Amazon.AWSECommerceServicePortTypeClient amzwc = new Amazon.AWSECommerceServicePortTypeClient();
    amzwc.ChannelFactory.Endpoint.EndpointBehaviors.Add(new AmazonSigningEndpointBehavior("ACCESS KEY", "SECRET KEY"));
                    
    ItemSearchResponse resp = amzwc.ItemSearch(search);
        
    foreach (Item item in resp.Items[0].Item)
         Console.WriteLine(item.ItemAttributes.Author[0] + " - " + item.ItemAttributes.Title);
