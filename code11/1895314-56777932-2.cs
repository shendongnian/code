        private void button3_click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (a, b) =>
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync("http://apiendpoint.com").Result;
                    textBox1.Invoke((Action)delegate 
                    { 
                       textBox1.Text = response.RequestMessage.ToString(); 
                    });
                }
            };
        }
