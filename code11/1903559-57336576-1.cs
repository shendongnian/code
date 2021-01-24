        private async Task<bool> IsBigRequestAllowed() {
            FileStream fileStream = File.Open("D:/Desktop/big.zip", FileMode.Open, FileAccess.Read, FileShare.Read);
            if(fileStream.Length == 0) {
                return true;
            }
            HttpRequestMessage = new HttpRequestMessage();
            HttpMethod = HttpMethod.Post;
            HttpRequestMessage.Method = HttpMethod;
            HttpRequestMessage.RequestUri = new Uri("https://localhost:55555/api/user/testupload");
            HttpRequestMessage.Content = new ByteArrayContent(new byte[] { });
            HttpRequestMessage.Content.Headers.ContentLength = fileStream.Length;
            try {
                HttpResponseMessage = await HttpClient.SendAsync(HttpRequestMessage);
                if (HttpResponseMessage.StatusCode == HttpStatusCode.NotFound) {
                    return false;
                }
                return true; // The code will never reach this line though
            }
            catch(HttpRequestException) {
                return true;
            }
        }
