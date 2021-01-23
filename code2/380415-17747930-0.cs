            var options = new List.SubscribeOptions{DoubleOptIn = true,EmailType = List.EmailType.Html,SendWelcome = false};
            var merges = new List<List.Merges> { new List.Merges("john@provider.com", List.EmailType.Html) { { "FNAME", "John" }, { "LNAME", "Smith" } } };
            var mcApi = new MCApi(apiKey, false);
 
            mcApi.ListBatchSubscribe(listId, merges, options);
