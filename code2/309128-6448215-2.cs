    ItemLookup itemLookup = new ItemLookup(){
        AssociateTag = "myaffiliatetag-20"
    };
    itemLookup.AWSAccessKeyId = MY_AWS_ID;
    ItemLookupRequest itemLookupRequest = new ItemLookupRequest();
    itemLookupRequest.IdTypeSpecified = true;
    itemLookupRequest.IdType = ItemLookupRequestIdType.UPC;
    itemLookupRequest.ItemId = new String[] { "9120031340300", "9120031340270" };
    itemLookupRequest.ResponseGroup = new String[] { "OfferSummary" };
    itemLookup.Request = new ItemLookupRequest[] { itemLookupRequest };
    
    ItemLookupResponse response = client.ItemLookup(itemLookup);
    foreach(var item in response.Items[0])
    {
      //Do something...
      Console.WriteLine(item.ItemAttributes.Title);
    }
