public async Task<bool> GetMedia(string saveDir, string id)
        {
            var api = $"/api/v1/download/{id}";
            var Uri = $"{MccBaseURL}{api}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(Uri, HttpCompletionOption.ResponseHeadersRead))
                using (System.IO.Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    string fileToWriteTo = System.IO.Path.GetTempFileName();
                    using (System.IO.FileStream streamToWriteTo = new System.IO.FileStream(saveDir, System.IO.FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                        return true;
                    }
                }
            }
        }
It was really memory something problem which continuously using same HttpClient over and over again. So I created a new instance. I'm a super noob! Sorry!
