    public sealed class CustomBinder : SerializationBinder {
        public override Type BindToType(string assemblyName, string typeName) {
            Type typeToDeserialize = null;
            if (typeName.IndexOf("SomeType") != -1) {
                typeToDeserialize = typeof(Foo.Bar.Bax.NewType);
            }
            else if (typeName.IndexOf("SomeOtherType") != -1) {
                typeToDeserialize = typeof(Foo.Bar.Bax.SomeOtherNewType);
            }
            else {
                // ... etc
            }
            return typeToDeserialize;
        }
    }
