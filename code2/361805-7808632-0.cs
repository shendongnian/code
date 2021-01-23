    private async Task<String> PostData(string url, string postData)
    {
      HttpWebRequest request = null;
      if (m_type == PostTypeEnum.Post)
      {
        Uri uri = new Uri(url);
        request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = postData.Length;
        using (Stream writeStream = await request.GetRequestStreamAsync())
        {
          UTF8Encoding encoding = new UTF8Encoding();
          byte[] bytes = encoding.GetBytes(postData);
          await writeStream.WriteAsync(bytes, 0, bytes.Length);
        }
      }
      else
      {
        Uri uri = new Uri(url + "?" + postData);
        request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "GET";
      }
      using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
      using (Stream responseStream = response.GetResponseStream())
      using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
      {
        return await readStream.ReadToEndAsync();
      }
    }
