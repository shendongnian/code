    var boundary = "------------------------" + DateTime.Now.Ticks;
    var newLine = Environment.NewLine;
    var propFormat = "--" + boundary + newLine +
                        "Content-Disposition: form-data; name=\"{0}\"" + newLine + newLine + 
                        "{1}" + newLine;
    var fileHeaderFormat = "--" + boundary + newLine +
                            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine;
    var req = (HttpWebRequest)HttpWebRequest.Create("http://jm/php/upload.php");
    req.Method = WebRequestMethods.Http.Post;
    req.ContentType = "multipart/form-data; boundary=" + boundary;
    using (var reqStream = req.GetRequestStream()) {
        var reqWriter = new StreamWriter(reqStream);
        var tmp = string.Format(propFormat, "str1", "hello world");
        reqWriter.Write(tmp);
        tmp = string.Format(propFormat, "str2", "hello world 2");
        reqWriter.Write(tmp);
        reqWriter.Write("--" + boundary + "--");
        reqWriter.Flush();
    }
    var res = req.GetResponse();
    using (var resStream = res.GetResponseStream()) {
        var reader = new StreamReader(resStream);
        txt1.Text = reader.ReadToEnd();
    }
