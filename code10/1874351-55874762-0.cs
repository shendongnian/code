    services.AddMvc()
        .AddRazorPagesOptions(o =>
        {
            o.Conventions.AddAreaFolderRouteModelConvention("Identity", "/", pageRouteModel =>
            {
                foreach (var selectorModel in pageRouteModel.Selectors)
                    selectorModel.AttributeRouteModel.Template = "PREFIX/" + selectorModel.AttributeRouteModel.Template;
            });
        });
