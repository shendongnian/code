     private CookieContainer cookieContainer;
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                var wr = (HttpWebRequest)WebRequest.Create("http://localhost/proj/guess-my-fav/1.jpg");
                cookieContainer = new CookieContainer();
                wr.CookieContainer = this.cookieContainer;
                var resp = (HttpWebResponse)wr.GetResponse();
                wr.CookieContainer = cookieContainer;
                using (var s = resp.GetResponseStream())
                {
                    pictureBox1.Image = new Bitmap(s);
                }
            }
 
    private void button1_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("http://localhost/proj/guess-my-fav/level14.php");
            var answer = textBox1.Text;
            string data = "guess=" + answer + "&level=14&time=opt";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.CookieContainer = cookieContainer;
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
        }
