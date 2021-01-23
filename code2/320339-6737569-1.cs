    class ClientData {
        public string TypeName;
        public string Data;
    }
    
    ...
    
    ClientData interim = JsonConvert.DeserializeObject<ClientData>(json);
    switch(interim.TypeName)  {
        // take the appropriate action for each type
        case "HistoricalLocalSettingsJSON ":
            historical = 
               JsonConvert.DeserializeObject<HistoricalLocalSettingsJSON >(interim.Data);
            break;
        case ...
    }
