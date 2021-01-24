var assemblyName = new AssemblyName("Test");
var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
var moduleBuilder = assemblyBuilder.DefineDynamicModule("Test");
Type baseCrudController = typeof(GenericBaseController<,>).MakeGenericType(typeof(Foo), typeof(int));
var tb = moduleBuilder.DefineType("FooController", TypeAttributes.Public, baseCrudController);
MethodBuilder builder = tb.DefineMethod("Get", MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Final, typeof(Foo), new[] { typeof(int) });
ConstructorInfo httpCtorInfo = typeof(HttpGetAttribute).GetConstructor(Type.EmptyTypes);
CustomAttributeBuilder httpAttrBuilder = new CustomAttributeBuilder(httpCtorInfo, new object[0]);
builder.SetCustomAttribute(httpAttrBuilder);
ILGenerator emitter = builder.GetILGenerator();
emitter.Emit(OpCodes.Ldarg_0);
emitter.Emit(OpCodes.Ldarg_1);
MethodInfo baseTypeMethod = baseCrudController.GetMethod("DoGet", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
emitter.Emit(OpCodes.Call, baseTypeMethod);
emitter.Emit(OpCodes.Ret);
// Test
var resultType = tb.CreateType();
var instance = Activator.CreateInstance(resultType);
var result = resultType.GetMethod("Get").Invoke(instance, new object[] { 3 });
