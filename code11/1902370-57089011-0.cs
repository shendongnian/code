 c#
foreach(var type in typeof(Animals).GetNestedTypes(
    BindingFlags.Public | BindingFlags.NonPublic))
{
    var method = type.GetMethod("GetAge", BindingFlags.Static | BindingFlags.Public,
        null, Type.EmptyTypes, null);
    if (method != null)
    {
        int age = (int)method.Invoke(null, null);
        Console.WriteLine(age);
    }
}
