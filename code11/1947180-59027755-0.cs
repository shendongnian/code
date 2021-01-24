        private void send(string item)
        {
            string html = "";
            string url = "http://open.api.ebay.com/shopping?appid=YOUR-APP-ID&version=969&siteid=77&callname=GetSingleItem&responseencoding=JSON&IncludeSelector=Variations,ItemSpecifics,Description,Details,VariationSpecifics&ItemID="+item;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse responce = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = responce.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }
            textBox1.Text=html;
            html = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            send(txtid.Text);
        }
