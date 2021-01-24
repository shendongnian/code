`C#
string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), address))
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", userAgentName);
                    httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                    httpClient.DefaultRequestHeaders.ExpectContinue = true;
                    var multipartContent = new MultipartFormDataContent(boundary);
                    multipartContent.Headers.Remove("Content-Type");
                    multipartContent.Headers.Add("Content-Type", "multipart/form-data; boundary="+boundary);
                    var bcd = new ByteArrayContent(System.IO.File.ReadAllBytes(path));
                    bcd.Headers.Clear();
                    bcd.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\""+fileName+"\"");
                    bcd.Headers.Add("Content-Type", "application/octet-stream");
                    multipartContent.Add(bcd, "file", fileName);
                    request.Content = multipartContent;
                    var response = await httpClient.SendAsync(request);
                }
            }
`
Now the headers from curl and the HttpClient are almost the same(Accept header is missing, but I don't need it).
