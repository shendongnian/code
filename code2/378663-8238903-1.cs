    HttpWebResponse response = (HttpWebResponse)clientx.GetResponse();
    if (response.StatusCode != HttpStatusCode.OK)
    {
        MessageBox.Show("Error reading page: " + response.StatusCode);
    }
    else
    {
        string FilePath = @"C:\TextFiles\" + FileName + String.Format("{0:00000}", i) + ".TXT";
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
        //MessageBox.Show(FilePath);
        using (FileStream download = new FileStream(FilePath, FileMode.Create))
        {
            Stream stream = response .GetResponseStream();
            while ((read = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                download.Write(buffer, 0, read);
            }
        }
    }
