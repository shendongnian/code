     public async void RunJob(IPacketMsg msg)
     {
         // Do Stuff
         var response = await GetResponse();
         // response is "string", not "Task<string>"
         // Do More Stuff
     }
     public Task<string> GetResponse()
     {
         return Task.Factory.StartNew(() =>
            {
                 _networkThingy.WaitForDataAvailable();
                 return _networkThingy.ResponseString;
            });
     }
