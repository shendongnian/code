    List<string> allUrls = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\test.txt").ToList();
    HtmlDocument doc = new HtmlDocument();
    foreach(string url in allUrls)
    {
        doc = new HtmlWeb().Load(url);
        Console.WriteLine(doc.DocumentNode.InnerHtml);
    }
Please note, i am only printing the entire website, you can use HtmlAgilityPack to actually scrape the data you are interested in (like pulling all the links, or specific class item.
* Read in the lines from File
* Load the data from URL using HtmlWeb.
* Iterate through each URL and get what you need. 
