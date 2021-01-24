Type parentType = typeof(BaseProduct);
Assembly assembly = Assembly.GetExecutingAssembly();
Type[] types = assembly.GetTypes();
var genericDefinition = typeof(BaseClass).GetMethod("SyncProductsByType");
foreach (Type type in types)
{
    if (type.IsSubclassOf(parentType))
    {
        genericDefinition.MakeGenericMethod(type).Invoke(instance, null);
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.type.issubclassof?view=netframework-4.8
