        public void SubScribeChannel()
        {
            _logger.LogInformation("!SubScribeChannel started!!");
            string channelName = _config.ActiveChannelName;
            var pubSub = _connectionMultiplexer.GetSubscriber();
            try
            {
                pubSub.Subscribe(channelName, async (channel, message) => await MessageActionAsync(message, channel));
            }
            catch(Exception ex)
            {
                _logger.LogInformation(String.Format("!error: {0}", ex.Message));
            }
            Debug.WriteLine("EOF");
        }
