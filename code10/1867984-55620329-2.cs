        public async void StartMessageLoopAsync()
        {
            while (true)
            {
                // read socket data asynchronously and populate the global DataBuffer
                await ProcessDataAsync();
                // this is going to run in UI thread but there is only DataReceived invocation
                if (DataBuffer.Count == 0)
                {
                    OnDataReceived();
                }
            }
        }
