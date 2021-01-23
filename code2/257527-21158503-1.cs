       sealed class VersionDeserializationBinder : SerializationBinder
      {
         public override Type BindToType(string assemblyName, string typeName)
        {
        Type typeToDeserialize = null;
        string currentAssemblyInfo = Assembly.GetExecutingAssembly().FullName;
        //my modification
        string currentAssemblyName = currentAssemblyInfo.Split(',')[0];
        if (assemblyName.StartsWith(currentAssemblyName))assemblyName = currentAssemblyInfo;
        typeToDeserialize = Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
        return typeToDeserialize;
    }
