            WebClient webclient = new WebClient();
            using (Stream stream = webclient.OpenRead(source))
            {
                Bitmap iconbitmap = new Bitmap(System.Drawing.Image.FromStream(stream));
                var icon = Icon.FromHandle((iconbitmap).GetHicon());
                FileStream fs = new FileStream("/test1.ico", FileMode.Create);
                icon.Save(fs);
                fs.Close();
            }
