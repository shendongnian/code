    public static T QueryJson<T>(this IDbConnection cnn, string sql, object param = null,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null,
            CommandType? commandType = null) where T: class
        {
            var result = cnn.Query<string>(sql, param, transaction, buffered, commandTimeout, commandType).ToList();
            if (!result.Any())
                return default(T);
            // Concats
            var sb = new StringBuilder();
            foreach (var jsonPart in result)
                sb.Append(jsonPart);
            var settings = new JsonSerializerSettings
            {
                // https://github.com/danielwertheim/jsonnet-contractresolvers
                // I use this Contract Resolver to set data to private setter properties
                ContractResolver = new PrivateSetterContractResolver()
            };
            // Using Json.Net to de-serialize objects
            return JsonConvert.DeserializeObject<T>(sb.ToString(), settings);
        }
