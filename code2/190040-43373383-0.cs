        private byte[] GetImage(string iconPath)
        {
            using (WebClient client = new WebClient())
            {
                byte[] pic = client.DownloadData(iconPath);
                //string checkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\1.png";
                //File.WriteAllBytes(checkPath, pic);
                return pic;
            }
        }
