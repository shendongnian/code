List<string> images = new List<string>;
foreach (string category in getCategory)
{
    images.Add(Directory.EnumerateFiles(Server.MapPath("~/" + category)).Select(fn => "~/" + category + "/" + Path.GetFileName(fn)));
}
ViewBag.Images = images;
