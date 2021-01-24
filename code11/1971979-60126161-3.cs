List<string> images = new List<string>;
foreach (string category in getCategory)
{
    images.AddRange(Directory.EnumerateFiles(Server.MapPath("~/" + category))
               .Select(fn => "~/" + category + "/" + Path.GetFileName(fn)).ToList());
}
ViewBag.Images = images;
What you are doing in your loop is returning only the final image as the result will be over written on each iteration.
