C#
//This is an arbitrary enum, this could be 'Gender', in your case
public enum TestEnum
{
    value1,
    value2,
    value3,
    value4,
}
And you want to write down an array of those enum values. Add a list of enums property (or array of enums) to your model. If you want the property name within the JSON to be one of the reserved words (like `enum`) either override the name using the [`JsonPropertyName`][2] attribute (and keep the name whatever makes most sense programmatically):
C#
public class TestsViewModel_Option1
{
    // In your case, this property could be called 'Genders' to be self-documenting
    [JsonPropertyName("enum")]
    public List<TestEnum> ListOfEnums { get; set; }
}
OR, use the `@` symbol if you really want the property name to be the reserved keyword and don't want to/can't use the attribute for some reason.
C#
public class TestsViewModel_Option2
{
    // Or use fixed-size array, TestEnum[], if needed
    public List<TestEnum> @enum { get; set; }
}
And now this is what your code looks like with the [`JsonSerializer`][3]:
C#
private static void SerializeListOfEnums()
{
    var model1 = new TestsViewModel_Option1
    {
        ListOfEnums = { TestEnum.value1, TestEnum.value3 }
    };
    var options = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter() }
    };
    // {"enum":["value1","value3"]}
    Console.WriteLine(JsonSerializer.Serialize(model1, options));
    var model2 = new TestsViewModel_Option2
    {
        @enum = { TestEnum.value1, TestEnum.value3 }
    };
    // {"enum":["value1","value3"]}
    Console.WriteLine(JsonSerializer.Serialize(model2, options));
}
  [1]: https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?view=netcore-3.1#enums-as-strings
  [2]: https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?view=netcore-3.1#customize-individual-property-names
  [3]: https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=netcore-3.1
