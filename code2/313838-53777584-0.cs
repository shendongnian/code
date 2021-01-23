    string imgurl = "https://fun.vin/frank-capra-jr";
            var documents = new HtmlWeb().Load(imgurl);
            var urls = (documents.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s))).ToList();
            int c = 0;
             foreach(string a in urls)
            {
                string url = a;
                using (WebClient webClient = new WebClient())
                {
                    string imageUrl = url;
                    //string saveLocation = @"C:\New folder (2)\car\someImage.jpg";
                    byte[] imageBytes;
                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                    WebResponse imageResponse = imageRequest.GetResponse();
                    Stream responseStream = imageResponse.GetResponseStream();
                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                        br.Close();
                    }
                    responseStream.Close();
                    imageResponse.Close();
                    int Hight = 0;
                    int wedht = 0;
                    Image image = null;
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                         image = Image.FromStream(stream);
                    }
                    ImageFormat ab = image.RawFormat;
                    string ext = new ImageFormatConverter().ConvertToString(ab);
                    //if (ImageFormat.Jpeg.Equals(image.RawFormat))
                    //{
                    //    // JPEG
                    //}
                    //else if (ImageFormat.Png.Equals(image.RawFormat))
                    //{
                    //    // PNG
                    //}
                    //else if (ImageFormat.Gif.Equals(image.RawFormat))
                    //{
                    //    // GIF
                    //}
                    Hight = image.Height;
                    wedht = image.Width;
                    if (!ImageFormat.Gif.Equals(image.RawFormat))
                    {
                        string saveLocation = @"C:\New folder (2)\car\someImage" + c + "." + ext;// + "jpg";
                        FileStream fs = new FileStream(saveLocation, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        try
                        {
                            bw.Write(imageBytes);
                            c++;
                        }
                        finally
                        {
                            fs.Close();
                            bw.Close();
                        }
                    }
                }
