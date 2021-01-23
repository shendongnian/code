public class ItemData
{
    public string Name { get; set; }
    public string Path { get; set; }
}
...
List<ItemData> items = new List<ItemData>(10);
for (int i = 0; i < 10; i++)
{
    items.Add(new ItemData { Name = "Something", Path = "Image path" });
}
this.image_panorama.ItemsSource = items;
