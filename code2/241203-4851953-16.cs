    kernel.Bind<IProductService>().To<ProductService>();
    kernel.Bind<IProductRepository>().To<L2SProductRepository>();
    Func<Type, IValidator> validatorFactory = type =>
    {
        var valType = typeof(Validator<>).MakeGenericType(entity.GetType());
        return (IValidator)kernel.Get(valType);
    };
    kernel.Bind<IValidationProvider>()
        .ToConstant(context => new ValidationProvider(validatorFactory));
	
    kernel.Bind<Validator<Product>>().To<ProductValidator>();
