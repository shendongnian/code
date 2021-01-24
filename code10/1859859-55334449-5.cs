    var jsonResolver = new RenamePropertySerializerContractResolver();
    jsonResolver.RenameProperty(typeof(Activity), "INAgentMACID", "AgentMACID");
    jsonResolver.RenameProperty(typeof(Activity), "OUTAgentMACID", "AgentMACID");
    
    var serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = jsonResolver;
    
    var activities = JsonConvert.DeserializeObject<IDictionary<int, Activity>>(json, serializerSettings);
