                <set-header name="Authorization" exists-action="override">
                <value>@{
                        string body = context.Request.Body.As<string>(preserveContent: true);
                        string contentType = "application/zip";
                        var base64String = (string)context.Variables.GetValueOrDefault<JObject>("body")["data"] ;
                        var bytes = Convert.FromBase64String(base64String); 
                        var contentLength = bytes.Length;
                        var hmacSha256 = new System.Security.Cryptography.HMACSHA256 { Key = Convert.FromBase64String(context.Variables.GetValueOrDefault<string>("storageKey")) };
                        var payLoad = string.Format("{0}\n\n\n{1}\n\n{2}\n\n\n\n\n\n\nx-ms-blob-type:BlockBlob\nx-ms-date:{3}\nx-ms-version:{4}\n{5}", 
                            "PUT", 
                            contentLength,
                            contentType,
                            context.Variables["date"],
                            context.Variables["version"],
                            "/" + context.Variables.GetValueOrDefault<string>("storageAccountName") + context.Variables.GetValueOrDefault<string>("resource"));
                        return "SharedKey "+ context.Variables.GetValueOrDefault<string>("storageAccountName") + ":" + Convert.ToBase64String(hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(payLoad)));
                    }</value>
            </set-header>
            <set-body>@{
                var base64String = (string)context.Variables.GetValueOrDefault<JObject>("body")["data"] ;
                var bytes = Convert.FromBase64String(base64String); 
                return bytes;         
            }</set-body>
