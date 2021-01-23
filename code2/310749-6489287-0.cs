    public class CustomViewModelBinder : DefaultModelBinder
    {
        private readonly IKernel _kernel;
        public CustomViewModelBinder(IKernel kernel)
        {
            _kernel = kernel;
        }
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            return _kernel.Get(modelType);
        }
    }
