    using NSwag;
    using NSwag.SwaggerGeneration.Processors;
    using NSwag.SwaggerGeneration.Processors.Contexts;
    using System.Threading.Tasks;
    
    namespace api.mstiDFE._Helpers.Swagger
    {
        public class AddRequiredHeaderParameter : IOperationProcessor
        {
            public Task<bool> ProcessAsync(OperationProcessorContext context)
            {
                context.OperationDescription.Operation.Parameters.Add(
                new SwaggerParameter
                {
                    Name = "token",
                    Kind = SwaggerParameterKind.Header,
                    Type = NJsonSchema.JsonObjectType.String,
                    IsRequired = false,
                    Description = "Chave de acesso à API, fornecida pela RevendaCliente",
                    Default = "Default Value"
                });
                return Task.FromResult(true);
            }
        }
    }
