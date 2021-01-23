    WebClient client = new WebClient();
    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
    byte[] bret = client.UploadData("http://www.website.com/post.php", "POST",
                System.Text.Encoding.ASCII.GetBytes("field1=value1&amp;field2=value2") );
    string sret = System.Text.Encoding.ASCII.GetString(bret);
