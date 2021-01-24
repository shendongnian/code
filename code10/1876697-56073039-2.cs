    [Fact]
    public async Task Test() {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
        services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
        services.AddMvc(o => {
            o.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
        });
        var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetService<IOptions<MvcOptions>>();
        var compositeDetailsProvider = new DefaultCompositeMetadataDetailsProvider(new List<IMetadataDetailsProvider>());
        var metadataProvider = new DefaultModelMetadataProvider(compositeDetailsProvider);
        var modelBinderFactory = new ModelBinderFactory(metadataProvider, options, serviceProvider);
        var parameterBinder = new ParameterBinder(
            metadataProvider,
            modelBinderFactory,
            new Mock<IObjectModelValidator>().Object,
            options,
            NullLoggerFactory.Instance);
        var parameter = new ParameterDescriptor() {
            Name = "parameter",
            ParameterType = typeof(DateTime)
        };
        var controllerContext = new ControllerContext() {
            HttpContext = new DefaultHttpContext() {
                RequestServices = serviceProvider // You must set this otherwise BinderTypeModelBinder will not resolve the specified type
            },
            RouteData = new RouteData()
        };
        var modelMetadata = metadataProvider.GetMetadataForType(parameter.ParameterType);
        var formCollection = new FormCollection(new Dictionary<string, StringValues>() {
            { "Foo", new StringValues("1964/12/02 12:00:00") }
        });
        var valueProvider = new FormValueProvider(BindingSource.Form, formCollection, CultureInfo.CurrentCulture);
        var modelBinder = modelBinderFactory.CreateBinder(new ModelBinderFactoryContext() {
            BindingInfo = parameter.BindingInfo,
            Metadata = modelMetadata,
            CacheToken = parameter
        });
        // Act
        var modelBindingResult = await parameterBinder.BindModelAsync(
            controllerContext,
            modelBinder,
            valueProvider,
            parameter,
            modelMetadata,
            value: null);
        // Assert
        Assert.True(modelBindingResult.IsModelSet);
    }
