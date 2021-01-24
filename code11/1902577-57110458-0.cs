    Image[,] images = new Image[26, 13];
            Parallel.For(0, 26, x => {
                Parallel.For(0, 13, y =>{
                    using (WebClient client = new WebClient())
                        images[x, y] = Image.FromStream(new MemoryStream(client.DownloadData(Get.TileURL(panoID, x, y))));
                });
            });
            using (Bitmap result = new Bitmap(26 * 512, 13 * 512))
            {
                for (int x = 0; x < 26; x++)
                    for (int y = 0; y < 13; y++)
                        using (Graphics g = Graphics.FromImage(result))
                            g.DrawImage(images[x, y], x * 512, y * 512);
                result.Save(file, format);
            }
