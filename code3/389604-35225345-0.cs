        public static async Task AddMessageAsJsonAsync<T>(this CloudQueue cloudQueue, T objectToAdd)
        {
            var messageAsJson = JsonConvert.SerializeObject(objectToAdd);
            var cloudQueueMessage = new CloudQueueMessage(messageAsJson);
            await cloudQueue.AddMessageAsync(cloudQueueMessage);
        }
