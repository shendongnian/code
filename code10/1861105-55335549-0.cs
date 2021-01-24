csharp
public static string ReadPrivateField(object obj, string fieldName)
{
    var type = obj.GetType();
    // NonPublic = obly search for private fields.
    // Instance = only search for non-static fields.
    var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
    return field.GetValue(obj) as string;
}
