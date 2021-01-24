    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using System.Linq;
    public class NamespaceRoutingConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var hasAttributeRouteModels = controller.Selectors
                    .Any(selector => selector.AttributeRouteModel != null);
                if (!hasAttributeRouteModels)
                {
                    controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel()
                    {
                        Template = controller.ControllerType.Namespace.Replace('.', '/') 
                            + "/[controller]/[action]/{id?}"
                    };
                }
            }
        }
    }
