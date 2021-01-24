            private async Task WithFinalizer(Action<Task> toExecute)
        {
          
            try
            {
                await toExecute();
            }
            finally
            {
               // cleanup here
            }
        }
        // Usage
        [Fact]
        public async Task TestIt()
        {
            await WithFinalizer(async =>
            {
             // your test
             });
        }
