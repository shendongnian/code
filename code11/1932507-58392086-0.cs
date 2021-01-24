 c#
var bf = new BinaryFormatter { Binder = MyBinder.Instance };
// etc
with
    class MyBinder : SerializationBinder
    {
        private MyBinder() { }
        public static MyBinder Instance { get; } = new MyBinder();
        public override Type BindToType(string assemblyName, string typeName)
        {
            // TODO: check assemblyName and typeName against some known list, and
            // return the Type that should be used, often *instead of* the
            // one it expected;
        }
        public override void BindToName(Type serializedType,
            out string assemblyName, out string typeName)
        {
            //TODO: the opposite
        }
    }
---
But this is hard work, and *absurdly* brittle. Your time would be *much* better spent porting to a different serializer, IMO. Happy to recommend some, depending on your needs.
---
Side note: they have tried *repeatedly* to kill `BinaryFormatter` for .NET Core, but it sadly survived.
