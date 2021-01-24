    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
    public RootController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    }
    public RootResultModel Get()
    {
        var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
            ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
        {
            Name = ad.AttributeRouteInfo.Template,
            Method = ad.ActionConstraints?.OfType<HttpMethodActionConstraint>().FirstOrDefault()?.HttpMethods.First(),
            }).ToList();
        var res = new RootResultModel
        {
            Routes = routes
        };
        return res;
    }
}
