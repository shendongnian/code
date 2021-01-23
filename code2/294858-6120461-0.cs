        byte[] fileBytes = null;
        WebClient client = new WebClient();
        fileBytes = client.DownloadData(url);
        MemoryStream theMemStream = new MemoryStream();
        theMemStream.Write(fileBytes, 0, fileBytes.Length);
        System.Drawing.Image img2 = System.Drawing.Image.FromStream(theMemStream);
