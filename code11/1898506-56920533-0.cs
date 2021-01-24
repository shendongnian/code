`
public static class MyTypeBuilder
{
  public static Type CompileResultType(List<PropertyInfo> yourListOfFields, string typeName)
  {
    TypeBuilder tb = GetTypeBuilder(typeName);
    ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
    // NOTE: assuming your list contains Field objects with fields FieldName(string) and FieldType(Type)
    foreach (var field in yourListOfFields)
      CreateProperty(tb, field.Name, field.PropertyType);
    Type objectType = tb.CreateType();
    return objectType;
  }
  private static TypeBuilder GetTypeBuilder(string typeSignature)
  {
    var an = new AssemblyName(typeSignature);
    AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
    TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
            TypeAttributes.Public |
            TypeAttributes.Class |
            TypeAttributes.AutoClass |
            TypeAttributes.AnsiClass |
            TypeAttributes.BeforeFieldInit |
            TypeAttributes.AutoLayout,
            null);
    return tb;
  }
  private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
  {
    FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
    PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
    MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
    ILGenerator getIl = getPropMthdBldr.GetILGenerator();
    getIl.Emit(OpCodes.Ldarg_0);
    getIl.Emit(OpCodes.Ldfld, fieldBuilder);
    getIl.Emit(OpCodes.Ret);
    MethodBuilder setPropMthdBldr =
        tb.DefineMethod("set_" + propertyName,
          MethodAttributes.Public |
          MethodAttributes.SpecialName |
          MethodAttributes.HideBySig,
          null, new[] { propertyType });
    ILGenerator setIl = setPropMthdBldr.GetILGenerator();
    Label modifyProperty = setIl.DefineLabel();
    Label exitSet = setIl.DefineLabel();
    setIl.MarkLabel(modifyProperty);
    setIl.Emit(OpCodes.Ldarg_0);
    setIl.Emit(OpCodes.Ldarg_1);
    setIl.Emit(OpCodes.Stfld, fieldBuilder);
    setIl.Emit(OpCodes.Nop);
    setIl.MarkLabel(exitSet);
    setIl.Emit(OpCodes.Ret);
    propertyBuilder.SetGetMethod(getPropMthdBldr);
    propertyBuilder.SetSetMethod(setPropMthdBldr);
  }
}
`
Then I created a method to merge the objects:
`
public static object Merge(object obj1, object obj2, string newTypeName)
{
  var obj1Properties = obj1.GetType().GetProperties();
  var obj2Properties = obj2.GetType().GetProperties();
  var properties = obj1Properties.Concat(obj2Properties).ToList();
  Type mergedType = MyTypeBuilder.CompileResultType(properties, newTypeName);
  object mergedObject = Activator.CreateInstance(mergedType);
  var mergedObjectProperties = obj2.GetType().GetProperties();
  
  foreach(var property in obj1Properties)
  {
    mergedObject.GetType().GetProperty(property.Name).SetValue(mergedObject, obj1.GetType().GetProperty(property.Name).GetValue(obj1, null) , null);
  }
  
  foreach(var property in obj2Properties)
  {
    mergedObject.GetType().GetProperty(property.Name).SetValue(mergedObject, obj2.GetType().GetProperty(property.Name).GetValue(obj2, null) , null);
  }
  return mergedObject;
}
`
To test the result:
`
object obj1 = new
{
  ID = 1,
  Title = "text",
  Test = new
  {
    Number = 20,
    IsSomething = false
  }
};
object obj2 = new
{
  Age = 22
};
object merged = Merge(obj1, obj2, "merged");
foreach(var x in merged.GetType().GetProperties())
{
  Console.WriteLine($"{x.Name} = {x.GetValue(merged, null)}");
}
Console.ReadLine();
`
The output is:
    ID = 1
    Title = text
    Test = { Number = 20, IsSomething = False }
    Age = 22
