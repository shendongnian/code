    private void button1_Click(object sender, EventArgs e)
    {
        Uri uri = new Uri("http://localhost/proj/guess-my-fav/level14.php");
        var answer = textBox1.Text;
        string data = "guess=" + answer + "&level=14&time=opt";
        
        CookieContainer cookies = new CookieContainer(); /* we want to have this for other call also
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
        request.Method = WebRequestMethods.Http.Post;
        request.CookieContainer = cookies;
        request.KeepAlive = true;
        request.ContentLength = data.Length;
        request.ContentType = "application/x-www-form-urlencoded";
        StreamWriter writer = new StreamWriter(request.GetRequestStream());
        writer.Write(data);
        writer.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string tmp = reader.ReadToEnd();
        response.Close();
        richTextBox1.AppendText(tmp); // log - delete this line 
        HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("http://localhost/proj/guess-my-fav/1.jpg");
        request2.CookieContainer = cookies;
        HttpWebResponse response2 = (HttpWebResponse)request.GetResponse();
        pictureBox1.Image = Image.LoadFromStream(response2.GetResponseStream());
    }
