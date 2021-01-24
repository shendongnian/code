    var url = "https://fantasy.eliteserien.no/a/statistics/cost_change_start";
        
    var httpClient = new HttpClient();
    var html = await httpClient.GetStringAsync(url);
        
    var htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(html);
    //This is the part of the code that takes information from the website
    //Note that this part matches your screenshot, in the html code
    //You can se that there is a table with class="ism-table ism-table--el"
    //This pice of code target that specific table
    var ProductsHtml = htmlDocument.DocumentNode.Descendants("table")
        .Where(node => node.GetAttributeValue("class", "")
        .Equals("ism-table ism-table--el")).ToList(); ;
        try{
        var ProductListItems = ProductsHtml[0].Descendants("tr")
        
        foreach (var ProductListItem in ProductListItems)
        {
            //This targets whats inside the table
            Console.WriteLine("Id: " +
    
            ProductListItem.Descendants("<HEADER>")
            .Where(node => node.GetAttributeValue("<CLASS>", "")
            .Equals("<CLASS=>")).FirstOrDefault().InnerText
        );
    }
