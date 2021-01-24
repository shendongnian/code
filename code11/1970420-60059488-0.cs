    var assets = new Dictionary<string, decimal>
    {
        { "Cash", memberHoldings.Data.MemberCashValues?.Sum(md => decimal.TryParse(md.Value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal cashValue) ? cashValue : 0) ?? 0 },
        { "Properties", memberHoldings.Data.MemberProperties?.Sum(mh => decimal.TryParse(mh.Value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal propertiesValue) ? propertiesValue : 0) ?? 0 }
    };
    if (scheme.Data.SchemeDetails?.SchemeStatus == "Active")
    {
        assets.Add("Equities", memberHoldings.Data.MemberEquities?.Sum(mh => decimal.TryParse(mh.Value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal equitiesValue) ? equitiesValue : 0) ?? 0 });
    }
    var model = new DashboardViewModel()
    {
        SchemeName = scheme.Data.SchemeDetails.SchemeName,
        Assets = assets
        ...
    }
