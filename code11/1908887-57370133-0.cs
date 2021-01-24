        [HttpPost]    
        public async Task Upload()
        {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
            
                var file = provider.Contents.FirstOrDefault();
            
                var body = await file.ReadAsByteArrayAsync();
            
                channel.BasicPublish(
                    exchange: "", 
                    routingKey: "hello", 
                    basicProperties: null, 
                    body: body);
       }
