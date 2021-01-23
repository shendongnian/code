        WebClient client = new WebClient();
        client.Headers.Add("Authorization",
                              String.Format("Basic {0}", authstring));
        client.Headers.Add("Content-Type",
                           "application/x-www-form-urlencoded");
        client.UseDefaultCredentials = true;
        byte[] resp = client.UploadData(url, "POST", postbytes);
