    private static void SaveTempData(
        IActionResult result,
        ITempDataDictionaryFactory factory,
        IList<IFilterMetadata> filters,
        HttpContext httpContext)
    {
        var tempData = factory.GetTempData(httpContext);
        for (var i = 0; i < filters.Count; i++)
        {
            if (filters[i] is ISaveTempDataCallback callback)
            {
                callback.OnTempDataSaving(tempData);
            }
        }
        if (result is IKeepTempDataResult)
        {
            tempData.Keep();
        }
        tempData.Save();
    }
