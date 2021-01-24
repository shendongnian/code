            var query = new QueryDefinition("SELECT c.ConfigId, c.ConfigDescription FROM c where c.DataSourceType='CSV'");
            var items = container.GetItemQueryStreamIterator(query);
            while (items.HasMoreResults)
            {
                using (ResponseMessage response = await items.ReadNextAsync())
                {
                    using (StreamReader sReader = new StreamReader(response.Content))
                    using (JsonTextReader jsonReader = new JsonTextReader(sReader))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        dynamic values = jsonSerializer.Deserialize<dynamic>(jsonReader).Documents;
                        Console.WriteLine($"Name: {values[0].ConfigId}");
                    }
                }
            }
