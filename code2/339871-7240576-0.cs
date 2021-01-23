    public sealed class FooAttribute
    {
        public FooAttribute(string id, string typeName)
        {
            var type = Type.GetType(typeName);
            // whatever the other ctor does with the System.Type...
        }
    }
