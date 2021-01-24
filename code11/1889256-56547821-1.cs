        public void WireUp()
        {
            // set the event handler
            mHubProxy.On("broadcastMessage", (string platform, string message) =>
            {
                if (OnMessageReceived != null)
                    OnMessageReceived(this, string.Format("{0}: {1}", platform, message));
            });
        }
