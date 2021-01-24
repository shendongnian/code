        using (ResponseMessage responseMessage = await container.ReadItemStreamAsync(
            partitionKey: new PartitionKey(partitionkey),
            id: playerid))
        {
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return Accepted();
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                ...
            }
        }
