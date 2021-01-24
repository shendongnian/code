    //...omitted for brevity
    var json = await result.Content.ReadAsStringAsync();
    try {
        vehicRec = Newtonsoft.Json.JsonConvert.DeserializeObject<VehicleRecord>(json);
        if(vehicRec == null) {
            //check for an array just in case
            var items = JsonConvert.DeserializeObject<VehicleRecord[]>(json);
            if(items != null && items.Length > 0) {
                vehicRec = items[0];
            }
        }
    }
    catch (Exception ex) { }
    if (vehicRec == null) {
        //...
    //...omitted for brevity
