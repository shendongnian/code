    StringBuilder sb = new StringBuilder();
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://example.com");
    using (var resp = request.GetResponse())
    {
        using(StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            char[10] block;
            sr.ReadBlock(block, 0, 10);
            if (block.CharEquals(myDelim))
                break;
            sb.Append();
        }
    }
    // Process the StringBuilder here.
