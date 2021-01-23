        private void PopulateListView()
        {
            ImageList images = new ImageList();
            images.Images.Add(
                LoadImage("http://www.website.com/892374_838.jpg"));
            images.Images.Add(
                LoadImage("http://www.website.com/23431_838.jpg"));
            listView1.SmallImageList = images;
            listView1.Items.Add("An item", 0);
            listView1.Items.Add("Another item item", 1);
        }
        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();
            Bitmap bmp = new Bitmap(responseStream);
            responseStream.Dispose();
            return bmp;
        }
