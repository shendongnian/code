using(ResourceWriter ren = new ResourceWriter(path))
{
    DataContextDataContext db = new DataContextDataContext();
    var result = db.MultiLanguages;
    foreach (var item in result.ToList())
    {
        ren.AddResource(item.key, item.en);
    }
}
