        private void Button2_Click(object sender, EventArgs e)
        {
            string urlAddress = "https://codal.ir";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    string data = readStream.ReadToEnd(); // Data variable here
                    readStream.Close();
                }
            }
        }
