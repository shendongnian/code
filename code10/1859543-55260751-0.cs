    public class CustomControllerConvention : IControllerModelConvention
    {
        private readonly string newEndpoint;
        public CustomControllerConvention(string newEndpoint)
        {
            this.newEndpoint = newEndpoint;
        }
        public void Apply(ControllerModel controllerModel)
        {
            if (controllerModel.ControllerType.AsType() != typeof(CustomController))
                return;
            foreach (var selectorModel in controllerModel.Selectors)
                selectorModel.AttributeRouteModel.Template = newEndpoint;
        }
    }
