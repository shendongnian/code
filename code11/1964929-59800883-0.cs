C#
private class CustomJsonConverterForType : JsonConverter<Type>
{
    public override Type Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Caution: Deserialization of type instances like this 
        // is not recommended and should be avoided
        // since it can lead to potential security issues.
        // If you really want this supported (for instance if the JSON input is trusted):
        // string assemblyQualifiedName = reader.GetString();
        // return Type.GetType(assemblyQualifiedName);
        throw new NotSupportedException();
    }
    public override void Write(Utf8JsonWriter writer, Type value,
        JsonSerializerOptions options)
    {
        // Use this with caution, since you are disclosing type information.
        writer.WriteStringValue(value.AssemblyQualifiedName);
    }
}
You can then add the custom converter into the options and pass that to `JsonSerializer.Serialize`:
C#
var options = new JsonSerializerOptions();
options.Converters.Add(new CustomJsonConverterForType());
Consider **re-evaluating** why you need the `Type` property on your class that is being serialized and deserialized to begin with.
See https://github.com/dotnet/corefx/issues/42712 for more information and context around why you shouldn't deserialize classes containing `Type` properties using `Type.GetType(string)`.
Here is more information on how to write a custom converter:
https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to
An approach that can work more safely (and hence what **I would recommend**) is to use a type discriminator enum which contains the list of statically known types that you expect and support and explicitly create those types based on the enum values within the `JsonConverter<Type>`.
Here's an example of what that would look like:
C#
// Let's assume these are the list of types we expect for the `Type` property
public class ExpectedType1 { }
public class ExpectedType2 { }
public class ExpectedType3 { }
public class CustomJsonConverterForType : JsonConverter<Type>
{
    public override Type Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
        Type type = typeDiscriminator switch
        {
            TypeDiscriminator.ExpectedType1 => typeof(ExpectedType1),
            TypeDiscriminator.ExpectedType2 => typeof(ExpectedType2),
            TypeDiscriminator.ExpectedType3 => typeof(ExpectedType3),
            _ => throw new NotSupportedException(),
        };
        return type;
    }
    public override void Write(Utf8JsonWriter writer, Type value,
        JsonSerializerOptions options)
    {
        if (value == typeof(ExpectedType1))
        {
            writer.WriteNumberValue((int)TypeDiscriminator.ExpectedType1);
        }
        else if (value == typeof(ExpectedType2))
        {
            writer.WriteNumberValue((int)TypeDiscriminator.ExpectedType2);
        }
        else if (value == typeof(ExpectedType3))
        {
            writer.WriteNumberValue((int)TypeDiscriminator.ExpectedType3);
        }
        else
        {
            throw new NotSupportedException();
        }
    }
    // Used to map supported types to an integer and vice versa.
    private enum TypeDiscriminator
    {
        ExpectedType1 = 1,
        ExpectedType2 = 2,
        ExpectedType3 = 3,
    }
}
private static void TypeConverterExample()
{
    var requestPayload = new RequestPayload
    {
        MessageName = "message",
        Payload = "payload",
        PayloadType = typeof(ExpectedType1)
    };
    var options = new JsonSerializerOptions()
    {
        Converters = { new CustomJsonConverterForType() }
    };
    string json = JsonSerializer.Serialize(requestPayload, options);
    Console.WriteLine(json);
    // {"MessageName":"message","Payload":"payload","PayloadType":1}
    RequestPayload roundtrip = JsonSerializer.Deserialize<RequestPayload>(json, options);
    Assert.Equal(typeof(ExpectedType1), roundtrip.PayloadType);
}
