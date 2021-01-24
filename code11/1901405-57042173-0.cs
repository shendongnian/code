    public override void ProcessRequest(HttpContext context)
        {
            string json;
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
            var data = JsonConvert.DeserializeObject<RequestData>(json);
            base.ProcessRequest(context);
            ProcessRequest(data);
        }
        
     private void ProcessRequest(RequestData data)
     {
     // ... your code 
     }
