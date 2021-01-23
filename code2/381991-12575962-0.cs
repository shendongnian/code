    public static class ModelValidationFactory
    {
        /// <summary>
        /// Builds a Lamda expression with the Func&lt;ModelMetadata, ControllerContext, ValidationAttribute, ModelValidator&gt; signature
        /// to instantiate a strongly typed constructor.  This used by the <see cref="DataAnnotationsModelValidatorProvider.RegisterAdapterFactory"/>
        /// and used (ultimately) by <see cref="ModelValidatorProviderCollection.GetValidators"/> 
        /// </summary>
        /// <param name="adapterType">Adapter type, expecting subclass of <see cref="ValidatorResourceAdapterBase{TAttribute}"/> where T is one of the <see cref="ValidationAttribute"/> attributes</param>
        /// <param name="attrType">The <see cref="ValidationAttribute"/> generic argument for the adapter</param>
        /// <returns>The constructor invoker for the adapter. <see cref="DataAnnotationsModelValidationFactory"/></returns>
        public static DataAnnotationsModelValidationFactory BuildFactory(Type adapterType, out Type attrType)
        {
            attrType = adapterType.BaseType.GetGenericArguments()[0];
            ConstructorInfo ctor = adapterType.GetConstructor(new[] { typeof(ModelMetadata), typeof(ControllerContext), attrType });
            ParameterInfo[] paramsInfo = ctor.GetParameters();
            ParameterExpression modelMetadataParam = Expression.Parameter(typeof(ModelMetadata), "metadata");
            ParameterExpression contextParam = Expression.Parameter(typeof(ControllerContext), "context");
            ParameterExpression attributeParam = Expression.Parameter(typeof(ValidationAttribute), "attribute");
            Expression[] ctorCallArgs = new Expression[]
            {
                modelMetadataParam,
                contextParam,
                Expression.TypeAs( attributeParam, attrType )
            };
            NewExpression ctorInvoker = Expression.New(ctor, ctorCallArgs);
            // ( ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute ) => new {AdapterType}(metadata, context, ({AttrType})attribute)
            return Expression
                .Lambda(typeof(DataAnnotationsModelValidationFactory), ctorInvoker, modelMetadataParam, contextParam, attributeParam)
                .Compile()
                as DataAnnotationsModelValidationFactory;
        }
    }
