internal class Item
{
    public double LiftMax { get; set; }
    public string LiftMaxText => LiftMax.ToString();
}
and
var item = JsonConvert.DeserializeObject<Item>(jsonFile)
radtextBox.Text = item.LiftMaxText;
