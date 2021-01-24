    public static void Register(HttpConfiguration config)
    {
        // To enable $select and $filter on all fields by default
        config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        config.SetDefaultQuerySettings(new Microsoft.AspNet.OData.Query.DefaultQuerySettings() { EnableCount = true, EnableExpand = true, EnableFilter = true, EnableOrderBy = true, EnableSelect = true, MaxTop = null });
        config.AddODataQueryFilter(new EnableQueryAttribute());
        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        
        // Set the timezone to UTC
        config.SetTimeZoneInfo(System.TimeZoneInfo.Utc);
        // Register the odata routes and other config
        ...
    }
