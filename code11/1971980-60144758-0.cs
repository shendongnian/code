    var data = new List<IEnumerable<string>>();
    foreach (string category in getCategory)
    {
        var images = Directory.EnumerateFiles(Server.MapPath("~/" + category)).Select(fn => "~/" + category + "/" + Path.GetFileName(fn));
        data.Add(images);
    }
    ViewBag.Images = data;
