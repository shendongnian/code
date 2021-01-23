    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                            "http://motif-x.med.harvard.edu/cgi-bin/multimotif-x.pl");
    request.ProtocolVersion = HttpVersion.Version10;
    request.Method = "POST";
    string boundary = "---------------------------7db1af18b064a";
    string newLine = "\r\n";
    string postData = "--" + boundary + newLine +
                      "Content-Disposition: form-data; name=\"fgdata\"" + newLine + newLine + "SGSLDSELSVSPKRNSISRTH" + newLine +
                      "--" + boundary + newLine +
                      "Content-Disposition: form-data; name=\"fgcentralres\"" + newLine + newLine + "S" + newLine +
                      "--" + boundary + newLine +
                      "Content-Disposition: form-data; name=\"width\"" + newLine + newLine + "21" + newLine +
                      "--" + boundary + "--";
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    request.ContentType = "multipart/form-data; boundary=" + boundary;
    request.ContentLength = byteArray.Length;
    Stream dataStream = request.GetRequestStream();
    dataStream.Write(byteArray, 0, byteArray.Length);
    dataStream.Close();
    using (WebResponse response = request.GetResponse())
    using (Stream resSteam = response.GetResponseStream())
    using (StreamReader sr = new StreamReader(resSteam))
        File.WriteAllText("SearchResults.html", sr.ReadToEnd());
    System.Diagnostics.Process.Start("SearchResults.html");
