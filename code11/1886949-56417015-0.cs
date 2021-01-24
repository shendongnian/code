    var jsonText = File.ReadAllText("test.txt");
    var json = JObject.Parse(jsonText);
    var pages = json.Descendants()
        .OfType<JObject>()
        .Where(o => o.Properties().Any(p => p.Name == "page"));
    foreach (var pageObject in pages)
    {
        var texts = pageObject.Descendants()
            .OfType<JProperty>()
            .Where(p => p.Name == "text" &&
                        p.Value.Value<string>().Replace(" ", "").Length == 12);
        var page = pageObject.Properties().First(p => p.Name == "page");
        foreach (var text in texts)
        {
            Console.WriteLine(text + " exist in page " + page.Value + " block");
        }
    }
