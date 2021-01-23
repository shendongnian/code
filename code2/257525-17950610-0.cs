    sealed class Version1ToVersion2DeserializationBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type typeToDeserialize = null;
                // For each assemblyName/typeName that you want to deserialize to a different type, set typeToDeserialize to the desired type.
                String assemVer1 = assemblyName;
                String typeVer1 = typeName;
                if (assemblyName == assemVer1 && typeName == typeVer1)
                {
                    // To use a type from a different assembly version, change the version number.
                    assemblyName = Assembly.GetExecutingAssembly().FullName;
                    // To use a different type from the same assembly, change the type name.
                    typeName = "projectname.typename";
                }
                // The following line of code returns the type.
                typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
                return typeToDeserialize;
            }
        }
