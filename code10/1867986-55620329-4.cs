        private async Task ProcessDataAsync()
        {
            await ReadDataAsync().ConfigureAwait(false);
            // this is going to run in background thread
            var dataEventArgs = new DataEventArgs();
            dataEventArgs.DataBuffer = DataBuffer;
        }
        public override async Task ReadDataAsync()
        {
            // read a data asynchronously
            var task = Task.Run(() => ReadData());
            await task;
        }
