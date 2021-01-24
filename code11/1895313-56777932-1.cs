        public void GetApiData()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://apiendpoint.com").Result;
                textBox1.Invoke((Action)delegate 
                { 
                  textBox1.Text = response.RequestMessage.ToString(); 
                });
            }
        }
