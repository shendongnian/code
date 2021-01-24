    public class ToothbrushPageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            if (model.RelativePath.StartsWith("/Areas/Administration"))
            {
                var selector = model.Selectors.First(s => s.AttributeRouteModel.Template.StartsWith("Administration/"));
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template.Replace("Administration/", "Toothbrush/");
    
            }
        }
    }
