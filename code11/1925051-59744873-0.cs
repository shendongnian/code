C#
public class BaseClass
{
    public int Int { get; set; }
}
public class DerivedA : BaseClass
{
    public string Str { get; set; }
}
public class DerivedB : BaseClass
{
    public bool Bool { get; set; }
}
You can create the following `JsonConverter<BaseClass>` that writes the type discriminator while serializing and reads it to figure out which type to deserialize. You can register that converter on the `JsonSerializerOptions`
C#
public class BaseClassConverter : JsonConverter<BaseClass>
{
    private enum TypeDiscriminator
    {
        BaseClass = 0,
        DerivedA = 1,
        DerivedB = 2
    }
    public override bool CanConvert(Type type)
    {
        return typeof(BaseClass).IsAssignableFrom(type);
    }
    
    public override BaseClass Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        if (!reader.Read()
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != "TypeDiscriminator")
        {
            throw new JsonException();
        }
        
        if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }
        BaseClass baseClass;
        TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
        switch (typeDiscriminator)
        {
            case TypeDiscriminator.DerivedA:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (DerivedA)JsonSerializer.Deserialize(ref reader, typeof(DerivedA));
                break;
            case TypeDiscriminator.DerivedB:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (DerivedB)JsonSerializer.Deserialize(ref reader, typeof(DerivedB));
                break;
            default:
                throw new NotSupportedException();
        }
        if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
        {
            throw new JsonException();
        }
        return baseClass;
    }
    public override void Write(
        Utf8JsonWriter writer,
        BaseClass value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        if (value is DerivedA derivedA)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.DerivedA);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, derivedA);
        }
        else if (value is DerivedB derivedB)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.DerivedB);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, derivedB);
        }
        else
        {
            throw new NotSupportedException();
        }
        writer.WriteEndObject();
    }
}
This is what serialization and deserialization would look like (including comparison with Newtonsoft.Json):
C#
private static void PolymorphicSupportComparison()
{
    var objects = new List<BaseClass> { new DerivedA(), new DerivedB() };
    // Using: System.Text.Json
    var options = new JsonSerializerOptions
    {
        Converters = { new BaseClassConverter() },
        WriteIndented = true
    };
    string jsonString = JsonSerializer.Serialize(objects, options);
    Console.WriteLine(jsonString);
    /*
     [
      {
        "TypeDiscriminator": 1,
        "TypeValue": {
            "Str": null,
            "Int": 0
        }
      },
      {
        "TypeDiscriminator": 2,
        "TypeValue": {
            "Bool": false,
            "Int": 0
        }
      }
     ]
    */
    var roundTrip = JsonSerializer.Deserialize<List<BaseClass>>(jsonString, options);
    // Using: Newtonsoft.Json
    var settings = new Newtonsoft.Json.JsonSerializerSettings
    {
        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
        Formatting = Newtonsoft.Json.Formatting.Indented
    };
    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(objects, settings);
    Console.WriteLine(jsonString);
    /*
     [
      {
        "$type": "PolymorphicSerialization.DerivedA, PolymorphicSerialization",
        "Str": null,
        "Int": 0
      },
      {
        "$type": "PolymorphicSerialization.DerivedB, PolymorphicSerialization",
        "Bool": false,
        "Int": 0
      }
     ]
    */
    var originalList = JsonConvert.DeserializeObject<List<BaseClass>>(jsonString, settings);
    Debug.Assert(originalList[0].GetType() == roundTrip[0].GetType());
}
Here's another StackOverflow question that shows how to support polymorphic deserialization with interfaces (rather than abstract classes), but a similar solution would apply for any polymorphism:
https://stackoverflow.com/questions/59743382/is-there-a-simple-way-to-manually-serialize-deserialize-child-objects-in-a-custo/59744188
