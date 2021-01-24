`
            string filenamefullyqualified = path + filename;
            Stream stream = System.IO.File.Open(filenamefullyqualified, FileMode.Open, FileAccess.Read, FileShare.None);
            //content.Add(CreateFileContent(fs, path, filename, "text/plain"));
            
            long? position = 0;
            byte[] buffer = new byte[(20 * 1024 * 1024) + 100];
            long numBytesToRead = stream.Length;
            int numBytesRead = 0;
            
            //while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            //{
            do
            {
                //var content = new MultipartFormDataContent();
                
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                byte[] actualbytes = new byte[bytesRead];
                Array.Copy(buffer, actualbytes, bytesRead);
                if (bytesRead == 0)
                    break;
                //Append Data
                url = String.Format("https://{0}.dfs.core.windows.net/raw/datawarehouse/{1}/{2}/{3}/{4}/{5}?action=append&position={6}", datalakeName, filename.Substring(0, filename.IndexOf("_")), year, month, day, filename, position.ToString());
                numBytesRead += bytesRead;
                numBytesToRead -= bytesRead;
                ByteArrayContent byteContent = new ByteArrayContent(actualbytes);
                //byteContent.Headers.ContentType= new MediaTypeHeaderValue("text/plain");
                //content.Add(byteContent);
                method = new HttpMethod("PATCH");
                //request = new HttpRequestMessage(method, url)
                //{
                //    Content = content
                //};
                request = new HttpRequestMessage(method, url)
                {
                    Content = byteContent
                };
                request.Headers.Add("Authorization", "Bearer " + accesstoken);
                
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                position = position + request.Content.Headers.ContentLength;
                Array.Clear(buffer, 0, buffer.Length);
            } while (numBytesToRead > 0);
            stream.Close();
`
