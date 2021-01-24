`cs
Parallel.ForEach(itemFiles, file =>
{
    var json = System.IO.File.ReadAllText(file);
    var itemObject = JsonConvert.DeserializeObject<ItemModel>(json);
    items.Add(itemObject);
}
`
