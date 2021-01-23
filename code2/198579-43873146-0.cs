        public static byte[] SerializeImage() {
            MemoryStream m;
            string PicPath = pathToImage";
            byte[] imageBytes;
            using (Image image = Image.FromFile(PicPath)) {
                
                using ( m = new MemoryStream()) {
                    image.Save(m, image.RawFormat);
                    imageBytes = new byte[m.Length];
                   //Very Important    
                   imageBytes = m.ToArray();
                    
                }//end using
            }//end using
            return imageBytes;
        }//SerializeImage
    
