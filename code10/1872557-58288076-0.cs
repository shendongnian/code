    context.OperationDescription.Operation.Parameters.Add(
        new OpenApiParameter
        {
            Name = "HEADER_NAME",
            Kind = OpenApiParameterKind.Header,
            Schema = new JsonSchema { Type = JsonObjectType.String },
            IsRequired = true,
            Description = "Description",
            Default = "Default Value"
        });
