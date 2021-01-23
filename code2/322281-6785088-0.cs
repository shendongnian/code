    string typeName = LoadAssemblyQualifiedNameFromSomewhere();
    Type type = Type.GetType(typeName);
    MethodInfo method = this.GetType()
                            .GetMethod("SomeFunc", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(type);
    object obj = method.Invoke(this, null);
