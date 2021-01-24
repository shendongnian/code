        private async Task MessageActionAsync(RedisValue message, string channel)
        {
            try
            {
                Transformer t = new Transformer(_logger);
                _logger.LogInformation(String.Format("!SubScribeChannel message received on message!! channel: {0}, message: {1}", channel, message));
                string transformedMessage = Transformer.TransformJsonStringData2Message(message);
                List<Document> documents = Transformer.Deserialize<List<Document>>(transformedMessage);
                await MergeToMongoDb(documents, channel);
                _logger.LogInformation("!Merged");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(String.Format("!error: {0}", ex.Message));
            }
        }
