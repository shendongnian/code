    static void Main()
    {
        var emailType = CreateEmailType();
        dynamic email = Activator.CreateInstance(emailType);
        email.From = "x@xpto.com";
        email.To = "y@acme.com";
        email.Subject = "Dynamic Type";
        email.Boby = "XmlSerializer can use this!";
    }
    static Type CreateEmailType()
    {
        var assemblyName = new AssemblyName("DynamicAssembly");
        var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        var typeBuilder = moduleBuilder.DefineType(
            "Email",
            (
                TypeAttributes.Public |
                TypeAttributes.Sealed |
                TypeAttributes.SequentialLayout |
                TypeAttributes.Serializable
            ),
            typeof(ValueType)
        );
        typeBuilder.DefineField("From", typeof(string), FieldAttributes.Public);
        typeBuilder.DefineField("To", typeof(string), FieldAttributes.Public);
        typeBuilder.DefineField("Subject", typeof(string), FieldAttributes.Public);
        typeBuilder.DefineField("Body", typeof(string), FieldAttributes.Public);
        return typeBuilder.CreateType();
    }
