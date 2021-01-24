C#
var wanteds = "word4";
var filter = Builders<MyModel>.Filter.Empty;
foreach (var wanted in wanteds.Split(','))
{
    filter = filter & Builders<MyModel>.Filter.Where(m => m.Str.Contains(wanted.Trim()));
}
var models = collection.Find(filter).ToList();
My model:
C#
class MyModel
{
    [BsonElement("id")]
    public int Id { get; set; }
    [BsonElement("str")]
    public string Str { get; set; }
}
You can customize the wanted string and string separator.
