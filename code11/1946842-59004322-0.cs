json
{
  "datatable": {
    "data": [
      "A85002072C",
      "1994-11-15",
      678.9
    ],
    "columns": [
      {
        "name": "series_id"
      },
      {
        "name": "date"
      },
      {
        "name": "value"
      }
    ]
  }
}
For reference, here's the C# class definition I'm deserializing to:
csharp
public class Model
{
    public string SeriesId { get; set; }
    public DateTime Date { get; set; }
    public Decimal? Value { get; set; }
}
And here's the proof-of-concept converter:
csharp
public sealed class ModelConverter : JsonConverter
{
    public static readonly ModelConverter Instance = new ModelConverter();
    private ModelConverter() {}
    public override bool CanConvert(Type objectType) => objectType == typeof(Model);
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var obj = JObject.Load(reader);
        var data = (JArray)obj["datatable"]["data"];
        var columns = (JArray)obj["datatable"]["columns"];
        if (data.Count != columns.Count)
            throw new InvalidOperationException("data and columns must contain same number of elements");
        var model = new Model();
        for (int i = 0; i < data.Count; i++)
        {
            // A "switch" works well enough so long as the number of fields is finite and small.
            // There are smarter approaches, but I've kept the implementation basic
            // in order to focus on the core problem that was presented.
            switch (columns[i]["name"].ToString())
            {
                case "series_id":
                    model.SeriesId = data[i].ToString();
                    break;
                case "date":
                    model.Date = data[i].ToObject<DateTime>();
                    break;
                case "value":
                    model.Value = data[i].ToObject<decimal?>();
                    break;
            }
        }
        return model;
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var data = new JArray();
        var columns = new JArray();
        var model = (Model)value;
        // Like the "switch" used in deserialization, these "if" blocks are
        // pretty rudimentary. There are better ways, but I wanted to keep
        // this proof-of-concept implementation simple.
        if (model.SeriesId != default(string))
        {
            data.Add(model.SeriesId);
            columns.Add(new JObject(new JProperty("name", "series_id")));
        }
        if (model.Date != default(DateTime))
        {
            data.Add(model.Date.ToString("yyyy-MM-dd"));
            columns.Add(new JObject(new JProperty("name", "date")));
        }
        if (model.Value != default(Decimal?))
        {
            data.Add(model.Value);
            columns.Add(new JObject(new JProperty("name", "value")));
        }
        var completeObj = new JObject();
        completeObj["datatable"] = new JObject();
        completeObj["datatable"]["data"] = data;
        completeObj["datatable"]["columns"] = columns;
        completeObj.WriteTo(writer);
    }
}
I wrote a few unit tests to verify the serializer. The tests are based on [xUnit.Net](https://github.com/xunit/xunit):
csharp
[Fact]
public void TestDeserializeSampleInputWithAllFields()
{
    var json = File.ReadAllText(BasePath + "sampleinput.json");
    var obj = JsonConvert.DeserializeObject<Model>(json, ModelConverter.Instance);
    Assert.Equal("A85002072C", obj.SeriesId);
    Assert.Equal(new DateTime(1994, 11, 15), obj.Date);
    Assert.Equal(678.9M, obj.Value);
}
[Fact]
public void TestSerializeSampleInputWithAllFields()
{
    var model = new Model
    {
        SeriesId = "A85002072C",
        Date = new DateTime(1994, 11, 15),
        Value = 678.9M,
    };
    var expectedJson = File.ReadAllText(BasePath + "sampleinput.json");
    Assert.Equal(expectedJson, JsonConvert.SerializeObject(model, Formatting.Indented, ModelConverter.Instance));
}
And to prove that the serializer works without all fields present:
json
{
  "datatable": {
    "data": [
      "B72008039G",
      543.2
    ],
    "columns": [
      {
        "name": "series_id"
      },
      {
        "name": "value"
      }
    ]
  }
}
csharp
[Fact]
public void TestDeserializeSampleInputWithNoDate()
{
    var json = File.ReadAllText(BasePath + "sampleinput_NoDate.json");
    var obj = JsonConvert.DeserializeObject<Model>(json, ModelConverter.Instance);
    Assert.Equal("B72008039G", obj.SeriesId);
    Assert.Equal(default(DateTime), obj.Date);
    Assert.Equal(543.2M, obj.Value);
}
[Fact]
public void TestSerializeSampleInputWithNoDate()
{
    var model = new Model
    {
        SeriesId = "B72008039G",
        Value = 543.2M,
    };
    var expectedJson = File.ReadAllText(BasePath + "sampleinput_NoDate.json");
    Assert.Equal(expectedJson, JsonConvert.SerializeObject(model, Formatting.Indented, ModelConverter.Instance));
}
