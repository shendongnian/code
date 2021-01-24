    var route = _localizationService.LocalRoutes().FirstOrDefault(p => p.Page == model.RelativePath);
    if (route != null)
    {
        model.Selectors.Add(new SelectorModel
        {
            AttributeRouteModel = new AttributeRouteModel
            {
                Template = "{version}"
            },
            ActionConstraints =
            {
                new VersionConstraint(route.Versions)
            }
        });
    }
