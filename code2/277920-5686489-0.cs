    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetCitiesWithState(string isoalpha2, string prefixText)
    {
        var dict = AtomicCore.CityObject.GetCitiesInCountryWithStateAutocomplete(isoalpha2, prefixText);
        string[] response = dict.Select(x => String.Format("{0}, {1}", x.Key, x.Value)).ToArray();
        return response;
    }
