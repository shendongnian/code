        List<WebResource> webResources = new List<WebResource>();
        webResources.Add(new WebResource() { Id = 1, Type = "Image", Url = "url1", Year = 2001 });
        webResources.Add(new WebResource() { Id = 1, Type = "Text", Url = "url1", Year = 2001 });
        webResources.Add(new WebResource() { Id = 3, Type = "Image", Url = "url1", Year = 2001 });
        webResources.Add(new WebResource() { Id = 1, Type = "Text", Url = "url1", Year = 2002 });
        webResources.Add(new WebResource() { Id = 2, Type = "Image", Url = "url1", Year = 2002 });
        webResources.Add(new WebResource() { Id = 3, Type = "Text", Url = "url2", Year = 2002 });
        webResources.Add(new WebResource() { Id = 1, Type = "Image", Url = "url1", Year = 2002 });
        webResources.Add(new WebResource() { Id = 2, Type = "Text", Url = "url2", Year = 2002 });
        var output = webResources.GroupBy(webResource => new {webResource.Id, webResource.Year, webResource.Url })
            .Select(group => new {Key = group.Key, Count = group.Count()});
        foreach (var webResource in output)
        {
            Console.WriteLine("Id: " + webResource.Key.Id +" Url:" + webResource.Key.Url + " Year:" + webResource.Key.Year + "  Count:" + webResource.Count);
        }
