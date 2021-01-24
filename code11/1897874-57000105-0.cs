`
// Just for convenience
public Type CreateNullableTypeFrom<T>()
{
  return CreateNullableTypeFrom(typeof(T));
}
public Type CreateNullableTypeFrom(Type typeToConvert)
{
  // Get the AssemblyName where the type is defined
  AssemblyName assembly = typeToConvert.Assembly.GetName();
  AssemblyBuilder dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
  ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule(assembly.Name);
  TypeBuilder typeBuilder = dynamicModule.DefineType(typeToConvert.Name + "Nullable");
  // Loop through the properties
  foreach(PropertyInfo property in typeToConvert.GetProperties())
  {
    // If property is value type, it can't be null
    if(property.PropertyType.IsValueType)
    {
      // Create a nullable type for the property
      typeBuilder.DefineProperty(property.Name, property.Attributes, typeof(Nullable<>).MakeGenericType(property.PropertyType), Type.EmptyTypes);
    }
    // The property can be null
    else
    {
      // Create a similar property
      typeBuilder.DefineProperty(property.Name, property.Attributes, property.PropertyType, Type.EmptyTypes);
    }
  }
  // Finally, create the type
  Type convertedType = typeBuilder.CreateType();
  Console.WriteLine(convertedType.Name);
  // Note: to access the properties of the converted type through reflection,
  //       use GetRuntimeProperties method, not GetProperties, since GetProperties
  //       will return an empty array because the type was created an runtime
  return convertedType;
}
`
