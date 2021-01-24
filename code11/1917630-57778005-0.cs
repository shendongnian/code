    foreach (var username in File.ReadAllLines("/Users/admin/Desktop/snap-scraper/snap-scraper/snapchats.txt"))
    {
        Console.WriteLine($"Attempting to grab QR for {username}");
    
        driver.Navigate().GoToUrl($"https://snapchat.com/add/{username}");
    
        Thread.Sleep(1000);
    
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(driver.PageSource);
    
        var image = htmlDocument.DocumentNode.SelectSingleNode("//img");
    
        if (image == null || !image.Attributes.Contains("src"))
        {
            Console.WriteLine($"Something went wrong for {username}");
            continue;
        }
    
        Console.WriteLine($"Got the QR for {username} yay");
    
        var src = image.Attributes.Where(x => x.Name == "src").First().Value;
    
        string filePath = $"/Users/admin/Desktop/snap-scraper/snap-scraper/images/{username}.jpg";
    
        // URL Decode Image - Remember to strip the start of the data url e.g. data:image/svg xml;utf8,
        string decodedUrl = WebUtility.UrlDecode(src.replace("data:image/svg xml;utf8,", ""));
    
        // Convert SVG string to byte array
        byte[] svgBytes = Encoding.UTF8.GetBytes(decodedUrl);
    
        // Write to byte array to disk
        File.WriteAllBytes(filePath, svgBytes);
    }
  
