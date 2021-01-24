    protected virtual object CreateModel(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        // If model creator throws an exception, we want to propagate it back up the call stack, since the
        // application developer should know that this was an invalid type to try to bind to.
        if (_modelCreator == null)
        {
            // The following check causes the ComplexTypeModelBinder to NOT participate in binding structs as
            // reflection does not provide information about the implicit parameterless constructor for a struct.
            // This binder would eventually fail to construct an instance of the struct as the Linq's NewExpression
            // compile fails to construct it.
            var modelTypeInfo = bindingContext.ModelType.GetTypeInfo();
            if (modelTypeInfo.IsAbstract || modelTypeInfo.GetConstructor(Type.EmptyTypes) == null)
            {
                var metadata = bindingContext.ModelMetadata;
                switch (metadata.MetadataKind)
                {
                    case ModelMetadataKind.Parameter:
                        throw new InvalidOperationException(
                            Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForParameter(
                                modelTypeInfo.FullName,
                                metadata.ParameterName));
                    case ModelMetadataKind.Property:
                        throw new InvalidOperationException(
                            Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForProperty(
                                modelTypeInfo.FullName,
                                metadata.PropertyName,
                                bindingContext.ModelMetadata.ContainerType.FullName));
                    case ModelMetadataKind.Type:
                        throw new InvalidOperationException(
                            Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForType(
                                modelTypeInfo.FullName));
                }
            }
            _modelCreator = Expression
                .Lambda<Func<object>>(Expression.New(bindingContext.ModelType))
                .Compile();
        }
        return _modelCreator();
    }
