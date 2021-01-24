    public void Apply(PageRouteModel model)
    {
        if(model.RelativePath.StartsWith("/Areas/MyArea"))
        {
            foreach(var selector in model.Selectors)
            {
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template.Replace("MyArea", string.Empty);
            }
        }
    }
