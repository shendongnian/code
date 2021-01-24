            static void UploadText()
            {
                string Account = "xxxx";
                string Key = "xxxx";
                string FileShare = "test1";
                string FileName = "11.txt";
                string apiversion = "2019-02-02";
                
                //the string to be uploaded to azure file, note that the length of the uploaded string should less than the azure file length
                string upload_text = "bbbbbbbbbbbbbbbbbbbbbbbb.";
                Console.WriteLine("the string length: " + upload_text.Length);
                DateTime dt = DateTime.UtcNow;
                string StringToSign = String.Format("PUT\n"
                    + "\n" // content encoding
                    + "\n" // content language
                    + upload_text.Length + "\n" // content length
                    + "\n" // content md5
                    + "\n" // content type
                    + "\n" // date
                    + "\n" // if modified since
                    + "\n" // if match
                    + "\n" // if none match
                    + "\n" // if unmodified since
                    + "\n"//+ "bytes=0-" + (upload_text.Length - 1) + "\n" // range
                    +"x-ms-date:" + dt.ToString("R") + "\nx-ms-range:bytes=0-"+(upload_text.Length-1) + "\nx-ms-version:" + apiversion + "\nx-ms-write:update\n" // headers
                    + "/{0}/{1}/{2}\ncomp:range", Account, FileShare, FileName);
    
                string auth = SignThis(StringToSign, Key, Account);
                string method = "PUT";
                string urlPath = string.Format("https://{0}.file.core.windows.net/{1}/{2}?comp=range", Account, FileShare,FileName);
                Uri uri = new Uri(urlPath);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;
                request.ContentLength = upload_text.Length;
                
                request.Headers.Add("x-ms-range", "bytes=0-"+(upload_text.Length-1));
                request.Headers.Add("x-ms-write", "update");
                request.Headers.Add("x-ms-date", dt.ToString("R"));
                request.Headers.Add("x-ms-version", apiversion);
                request.Headers.Add("Authorization", auth);
                //request.Headers.Add("Content-Length", upload_text.Length.ToString());
    
                var bytes = System.Text.Encoding.ASCII.GetBytes(upload_text);
    
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
    
    
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //read the content
                    Console.WriteLine("the response is:" + response.StatusCode);
                }
            }
            private static String SignThis(String StringToSign, string Key, string Account)
            {
                String signature = string.Empty;
                byte[] unicodeKey = Convert.FromBase64String(Key);
                using (HMACSHA256 hmacSha256 = new HMACSHA256(unicodeKey))
                {
                    Byte[] dataToHmac = System.Text.Encoding.UTF8.GetBytes(StringToSign);
                    signature = Convert.ToBase64String(hmacSha256.ComputeHash(dataToHmac));
                }
    
                String authorizationHeader = String.Format(
                      CultureInfo.InvariantCulture,
                      "{0} {1}:{2}",
                      "SharedKey",
                      Account,
                      signature);
    
                return authorizationHeader;
            }
