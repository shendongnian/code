     app.Use(async (context, nextMiddleware) =>
                {
                    context.Request.EnableRewind();
                    Stream originalBody = context.Response.Body;
    
                    try
                    {
                        using (var memStream = new MemoryStream())
                        {
                            context.Response.Body = memStream;
    
                            await nextMiddleware();
    
                            memStream.Position = 0;
                            string responseBody = new StreamReader(memStream).ReadToEnd();
    
    
                            memStream.Position = 0;
                            byte[] data = Encoding.UTF8.GetBytes(responseBody);//Encrypt responseBody here
                            memStream.Write(data, 0, data.Length);
    
    
                            memStream.Position = 0;
    
                            await memStream.CopyToAsync(originalBody);
                        }
    
                    }
                    finally
                    {
                        context.Response.Body = originalBody;
                    }
                });
