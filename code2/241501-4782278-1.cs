	BingService.BingService service = new BingService.BingService();
            SearchRequest request = new SearchRequest();
            // use your Bing AppID
            request.AppId = ""; /* Your App ID */
            request.Query = "rose"; // your search query
            // I want to search only web
            request.Sources = new SourceType[]
            {
                SourceType.Image 
            };
            SearchResponse response = service.Search(request);
            foreach (ImageResult result in response.Image.Results)
            {
                //lstBxImages.Items.Add("<a href="+result.Url + '"'+"></a>" + result.Title);
                imgliteral.Controls.Add(new LiteralControl("<img src=" + result.MediaUrl + " width=100
