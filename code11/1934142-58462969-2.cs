    var myModel = JsonConvert.DeserializeJson<List<Response>>(json);
    // access by iterating through properties
    foreach (var item in response)
    {
        foreach (var saveValue in item.SaveValues)
        {
            // get all properties of saveValue...
            // saveValue.Allposition;
            // saveValue.Allrotation;
            // saveValue.Allscale;
            // ....
        }
    }
