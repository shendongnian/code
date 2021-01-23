    public static TReturn GetDataFromJsonResult<TJsonType, TReturn>(this ActionResult result) where TJsonType : ActionResult
    {
        var jsonResult = (TJsonType)result;
        var data = jsonResult.GetType().GetProperty("Data").GetValue(jsonResult);
        return (TReturn)data;
    }
