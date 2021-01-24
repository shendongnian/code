await Next.Invoke(context);
            if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403 || context.Response.StatusCode == 405)
            {
                var owinResponse = context.Response;
                var owinResponseStream = owinResponse.Body;
                var responseBuffer = new MemoryStream();
                owinResponse.Body = responseBuffer;
Its wrong.
Next code snipet work as you want:
public override async Task Invoke(IOwinContext context)
        {
            var owinResponse = context.Response;
            var owinResponseStream = owinResponse.Body;
            var responseBuffer = new MemoryStream();
            owinResponse.Body = responseBuffer;
            await Next.Invoke(context);
            if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403 || context.Response.StatusCode == 405)
            {
             
                string message;
                switch (context.Response.StatusCode)
                {
                    case 401:
                        message = "unauthorized request";
                        break;
                    case 403:
                        message = "forbidden request";
                        break;
                    default:
                        message = "request not allowed";
                        break;
                }
                var newResponse = new ResponseMessage<string>
                {
                    IsError = true,
                    StatusCode = (HttpStatusCode) Enum.Parse(typeof(HttpStatusCode), context.Response.StatusCode.ToString()),
                    Data = null,
                    Message = message
                };
                var customResponseBody = new StringContent(JsonConvert.SerializeObject(newResponse));
                var customResponseStream = await customResponseBody.ReadAsStreamAsync();
                await customResponseStream.CopyToAsync(owinResponseStream);
                owinResponse.ContentType = "application/json";
                owinResponse.ContentLength = customResponseStream.Length;
                owinResponse.StatusCode = 200;
                owinResponse.Body = owinResponseStream;
            }
        }
