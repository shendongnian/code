        public HttpResponseMessage Get(int rows)
        {
            ICommand cmd = new Command(connStr);
            
            HttpResponseMessage response = Request.CreateResponse();
            response.Content = new PushStreamContent(async (stream, content, context) => 
            {
                
                await cmd
                .Proc("cuh.GetADDRESSES")
                .Param("@rows", rows)
                .Stream(stream, "[]");
                stream.Dispose();//This is the missing part to get it work
                
            }, "application/json");
            
            return response;
        }
