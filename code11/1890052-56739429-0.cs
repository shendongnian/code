    var classesToMap = typeof(Startup)
                    .Assembly
                    .GetTypes()
                    .Where(t => t.IsClass && t.BaseType.IsGenericOf(typeof(AppRequest<>)));
                var settings = new JsonSchemaGeneratorSettings()
                {
                    FlattenInheritanceHierarchy = true,
                };
                foreach (var type in classesToMap)
                {
                    var actualSchema = JsonSchema4.FromTypeAsync(type,settings).Result;
                    options.TypeMappers.Add(new ObjectTypeMapper(type.BaseType, actualSchema));
                }
