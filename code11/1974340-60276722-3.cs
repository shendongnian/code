    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    
    namespace SwaggerDocsHelpers
    {
        /// <summary>
        /// Add enum value descriptions to Swagger
        /// https://stackoverflow.com/a/49941775/1910735
        /// </summary>
        public class EnumDocumentFilter : IDocumentFilter
        {
            /// <inheritdoc />
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                // add enum descriptions to result models
                foreach (var schemaDictionaryItem in swaggerDoc.Definitions)
                {
                    var schema = schemaDictionaryItem.Value;
                    foreach (var propertyDictionaryItem in schema.Properties)
                    {
                        var property = propertyDictionaryItem.Value;
                        var propertyEnums = property.Enum;
                        if (propertyEnums != null && propertyEnums.Count > 0)
                        {
                            property.Description += DescribeEnum(propertyEnums);
                        }
                    }
                }
    
                if (swaggerDoc.Paths.Count <= 0) return;
    
                // add enum descriptions to input parameters
                foreach (var pathItem in swaggerDoc.Paths.Values)
                {
                    DescribeEnumParameters(pathItem.Parameters);
    
                    // head, patch, options, delete left out
                    var possibleParameterisedOperations = new List<Operation> { pathItem.Get, pathItem.Post, pathItem.Put };
                    possibleParameterisedOperations.FindAll(x => x != null)
                        .ForEach(x => DescribeEnumParameters(x.Parameters));
                }
            }
    
            private static void DescribeEnumParameters(IList<IParameter> parameters)
            {
                if (parameters == null) return;
    
                foreach (var param in parameters)
                {
                    if (param is NonBodyParameter nbParam && nbParam.Enum?.Any() == true)
                    {
                        param.Description += DescribeEnum(nbParam.Enum);
                    }
                    else if (param.Extensions.ContainsKey("enum") && param.Extensions["enum"] is IList<object> paramEnums &&
                      paramEnums.Count > 0)
                    {
                        param.Description += DescribeEnum(paramEnums);
                    }
                }
            }
    
            private static string DescribeEnum(IEnumerable<object> enums)
            {
                var enumDescriptions = new List<string>();
                Type type = null;
                foreach (var enumOption in enums)
                {
                    if (type == null) type = enumOption.GetType();
                    enumDescriptions.Add($"{Convert.ChangeType(enumOption, type.GetEnumUnderlyingType())} = {Enum.GetName(type, enumOption)}");
                }
    
                return $"{Environment.NewLine}{string.Join(Environment.NewLine, enumDescriptions)}";
            }
        }
    
        public class EnumFilter : ISchemaFilter
        {
            public void Apply(Schema model, SchemaFilterContext context)
            {
                if (model == null)
                    throw new ArgumentNullException("model");
    
                if (context == null)
                    throw new ArgumentNullException("context");
    
    
                if (context.SystemType.IsEnum)
                {
    
                    var enumUnderlyingType = context.SystemType.GetEnumUnderlyingType();
                    model.Extensions.Add("x-ms-enum", new
                    {
                        name = context.SystemType.Name,
                        modelAsString = false,
                        values = context.SystemType
                        .GetEnumValues()
                        .Cast<object>()
                        .Distinct()
                        .Select(value =>
                        {
                            //var t = context.SystemType;
                            //var convereted = Convert.ChangeType(value, enumUnderlyingType);
                            //return new { value = convereted, name = value.ToString() };
                            return new { value = value, name = value.ToString() };
                        })
                        .ToArray()
                    });
                }
            }
        }
    
    
        /// <summary>
        /// Adds extra schema details for an enum in the swagger.json i.e. x-enumNames (used by NSwag to generate Enums for C# client)
        /// https://github.com/RicoSuter/NSwag/issues/1234
        /// </summary>
        public class NSwagEnumExtensionSchemaFilter : ISchemaFilter
        {
            public void Apply(Schema model, SchemaFilterContext context)
            {
                if (model == null)
                    throw new ArgumentNullException("model");
    
                if (context == null)
                    throw new ArgumentNullException("context");
    
    
                if (context.SystemType.IsEnum)
                {
                    var names = Enum.GetNames(context.SystemType);
                    model.Extensions.Add("x-enumNames", names);
                }
            }
        }
    }
