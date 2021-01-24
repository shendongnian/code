        try
        {
            // GUID need to be specified in single quote. using OData v 3.0
            var odataquery = new ODataQuery<StreamingLocator>("name eq '65a1cb0d-ce7c-4470-93ac-fedf66450ea0'");
            IPage<StreamingLocator> locators = client.StreamingLocators.List("mediatest", "mymediatestaccount", odataquery);
            Console.WriteLine(locators.FirstOrDefault().Name);
            Console.WriteLine(locators.FirstOrDefault().StreamingLocatorId);
            Console.WriteLine(locators.FirstOrDefault().Id);
            ListPathsResponse paths = client.StreamingLocators.ListPaths("mediatest", "mymediatestaccount", locators.FirstOrDefault().Name);
            foreach (StreamingPath path in paths.StreamingPaths)
            {
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Scheme = "https";
                uriBuilder.Host = "webinars-use2.streaming.media.azure.net";
                uriBuilder.Path = path.Paths[0];
                Console.WriteLine(uriBuilder.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
