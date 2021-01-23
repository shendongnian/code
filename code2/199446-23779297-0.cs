    protected void BindModel<TModel>(Controller controller, TModel viewModel)
    {
        var controllerContext = SetUpControllerContext(controller, viewModel);
        var bindingContext = new ModelBindingContext
        {
            ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => viewModel, typeof(TModel)),
            ValueProvider = new JsonValueProviderFactory().GetValueProvider(controllerContext)
        };
        new DefaultModelBinder().BindModel(controller.ControllerContext, bindingContext);
        controller.ModelState.Clear();
        controller.ModelState.Merge(bindingContext.ModelState);
    }
    private static ControllerContext SetUpControllerContext<TModel>(Controller controller, TModel viewModel)
    {
        var controllerContext = A.Fake<ControllerContext>();
        controller.ControllerContext = controllerContext;
        var json = new JavaScriptSerializer().Serialize(viewModel);
        A.CallTo(() => controllerContext.Controller).Returns(controller);
        A.CallTo(() => controllerContext.HttpContext.Request.InputStream).Returns(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        A.CallTo(() => controllerContext.HttpContext.Request.ContentType).Returns("application/json");
        return controllerContext;
    }
