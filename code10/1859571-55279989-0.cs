    private static async void SendFiles(string path)
            {    
                var bytes = File.ReadAllBytes(path);
                var length = bytes.Length;
    
                foreach (var b in bytes)
                {
                    length--;
                    string sendFilesUrl = $"http://api/communication/sendF/{b}/{length}";
    
                    StringContent queryString = new StringContent(bytes.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");          
    
                    HttpResponseMessage response = await client.PostAsync(sendFilesUrl, queryString);
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
            }
