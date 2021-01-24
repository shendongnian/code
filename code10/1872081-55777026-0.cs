        public static string ImageToBase64(string filePath)
        {
            string base64String;
            using (var image = SixLabors.ImageSharp.Image.Load(filePath))
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new PngEncoder());
                    image.Dispose();
                    byte[] imageBytes = ms.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    imageBytes = null;
                    ms.Dispose();
                }
            }
            GC.Collect();
            return base64String;
        }
