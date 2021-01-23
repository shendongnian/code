    using (HttpClient client = new HttpClient())
    {
            using (HttpResponseMessage response = await client.GetAsync(downloadURL))
            {
                 using(var stream = await response.Content.ReadAsStreamAsync())
                 {
                      using(Stream zip = FileManager.OpenWrite(ZIP_PATH))
                      {
                           stream.CopyTo(zip);
                      }
                 }
            }
    }
