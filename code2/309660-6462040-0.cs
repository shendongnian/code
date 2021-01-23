    if (!(string.IsNullOrEmpty(ISBN) && string.IsNullOrEmpty(ASIN)))
    {
        AWSECommerceServicePortTypeClient client = new AWSECommerceServicePortTypeClient();
        client.ChannelFactory.Endpoint.Behaviors.Add(
            new Amazon.AmazonSigningEndpointBehavior(
                accessKeyId,
                secretKey);
        ItemLookup lookup = new ItemLookup();
        ItemLookupRequest request = new ItemLookupRequest();
        lookup.AssociateTag = accessKeyId;
        lookup.AWSAccessKeyId = secretKey;
    //... etc.
