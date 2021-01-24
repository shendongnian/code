    public class MyV1SchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (context.SystemType != MyProject.Models.v1.MyModel) return;
            /// configure v1 schema
        }
    }
    public class MyV2SchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (context.SystemType != MyProject.Models.v2.MyModel) return;
            /// configure v2 schema
        }
    }
You could also put it all in one Filter:
    public class MySchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (context.SystemType == MyProject.Models.v1.MyModel)
            {
                /// configure v1 schema
            }
            else if (context.SystemType == MyProject.Models.v2.MyModel)
            {
                /// configure v2 schema
            }
        }
    }
If you are doing it in a way where both versions are somehow represented by the same Class, then maybe you need to separate them.
DocumentFilterContext seems like it has enough data in there for it to know which version it was passed, as well.
