    var query = new QueryDefinition("SELECT value count(1) FROM c WHERE c.tenantId = @type");
            query.WithParameter("@type", '5d484526d76e9653e6226aa2');
            var container = client.GetContainer(_apolloConfig.DatabaseName, _apolloConfig.Collection);
            var iterator = container.GetItemQueryIterator<int>(query);
            var count = 0;
            while (iterator.HasMoreResults)
            {
                var currentResultSet = await iterator.ReadNextAsync();
                foreach (var res in currentResultSet)
                {
                    count += res;
                }
            }
            Console.WriterLine($"The first count is: {count}");
