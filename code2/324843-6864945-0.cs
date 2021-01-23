    class FooExporter : IExporter
    {
        public void Export(ExportContext context, object value, JsonWriter writer)
        {
            var properties = value.GetType().GetProperties();
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value, null);
                if (!JsonNull.LogicallyEquals(propertyValue))
                {
                    writer.WriteMember(property.Name);
                    context.Export(propertyValue, writer);
                }
            }
            writer.WriteEndObject();
        }
        public Type InputType
        {
            get { return typeof(Foo); }
        }
    }
