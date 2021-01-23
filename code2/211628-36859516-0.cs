    public static void DownloadFile(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.OpenRead(url);
                string header_contentDisposition = client.ResponseHeaders["content-disposition"];
                string filename = new ContentDisposition(header_contentDisposition).FileName;
                //Start the download and copy the file to the destinationFolder
                client.DownloadFile(new Uri(url), @"c:\temp\" + filename);
            }
        }
