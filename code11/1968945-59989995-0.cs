string json =
    JsonConvert.SerializeObject(
        exception,
        Formatting.Indented,
        new JsonSerializerSettings { 
             ContractResolver = new DefaultContractRresolver {
                   IgnoreSerializableInterface=true
        }}
    );
