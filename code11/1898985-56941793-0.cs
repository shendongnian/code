    public class DateTimeSchemaFilter: ISchemaFilter {
    
        public void Apply(Schema schema, SchemaFilterContext context) 
        {
            var typeInfo = context.SystemType;
            if (typeInfo == typeof(DateTime ? )) 
            {
                schema.Description = "Description";
            }
        }
    }
