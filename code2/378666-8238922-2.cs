    using(HttpWebReponse response = (HttpWebResponse)clientx.GetResponse())
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            string FilePath = @"C:\TextFiles\" + FileName + String.Format("{0:00000}", i) + ".TXT";
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            using (FileStream download = new FileStream(FilePath, FileMode.Create))
            {
                Stream stream = clientx.GetResponse().GetResponseStream();
                while ((read = stream.Read(buffer, 0, buffer.Length)) !=0)
                {
                    download.Write(buffer, 0, read);
                }
            } 
        }
    }
