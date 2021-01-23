			com.amazon.webservices.ItemLookup itemLookup = new com.amazon.webservices.ItemLookup();
            itemLookup.AWSAccessKeyId = "XXXXXXXXXXXXXXXXXXXXXX";
            com.amazon.webservices.ItemLookupRequest request = new com.amazon.webservices.ItemLookupRequest();
            request.IdType = com.amazon.webservices.ItemLookupRequestIdType.UPC;
            request.ItemId = new String[] { "00028000133177" };
            request.ResponseGroup = new String[] { "Small", "AlternateVersions" };
            itemLookup.Request = new com.amazon.webservices.ItemLookupRequest[] { request };
            try
            {
                com.amazon.webservices.ItemLookupResponse itemLookupResponse = com.amazon.webservices.AWSECommerceService.ItemLookup(itemLookup);
                com.amazon.webservices.Item item = itemLookupResponse.Items[0].Item[0];
                System.Console.WriteLine(item.ItemAttributes.Title);
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e);
            }
