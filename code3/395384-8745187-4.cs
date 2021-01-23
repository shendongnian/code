    var schema = new JsonSchemaGenerator().Generate(typeof(CustomType));
    Debug.Assert(schema.Properties.Count == 0);
    using (TextWriter textWriter = File.CreateText(@"schema.json"))
    using (var jsonTextWriter = new JsonTextWriter(textWriter))
    {
        jsonTextWriter.Formatting = Formatting.Indented;
        schema.WriteTo(jsonTextWriter);
    }
    // CustomType is a class without any fields/properties
    public class CustomType { }
