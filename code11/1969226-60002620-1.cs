    using JsonNet.PrivateSettersContractResolvers;
    ...
    var value = JsonConvert.DeserializeObject<Product>(_cache.StringGet("Redis_Key"),
            new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            });
