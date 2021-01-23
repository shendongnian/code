    kernel.Bind<IProductService>().To<ProductService>();
    kernel.Bind<IProductRepository>().To<L2SProductRepository>();
    Func<Type, IValidator> validatorFactory = type =>
    {
        var valType = typeof(Validator<>).MakeGenericType(type);
        return (IValidator)kernel.Get(valType);
    };
    kernel.Bind<IValidationProvider>()
        .ToConstant(new ValidationProvider(validatorFactory));
    
    kernel.Bind<Validator<Product>>().To<ProductValidator>();
