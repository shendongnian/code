            public enum ImageType : byte {jpg,jpeg,png,gif}  
     
            private byte[] Get_Image(HttpPostedFile file)
            {
                ImageType type = GetType(file.ContentType); 
                if (file.InputStream.Length <= 1)
                    return null;
                byte[] imageData = new byte[file.InputStream.Length + 1 + 1];
                file.InputStream.Read(imageData, 1, imageData.Length+1);
                imageData[0] =(byte)type;
                return imageData;
             }
             private ImageType GetType(string _type)
             {
                ImageType t = default(ImageType); 
                string s = _type.Substring(_type.IndexOf('/')+1).ToLower() ;
                switch (s)
                {
                     case "jpg": t = ImageType.jpg;
                          break;
                     case "jpeg": t = ImageType.jpeg;
                          break;
                     case "png": t = ImageType.png;
                          break;
                     case "gif": t = ImageType.gif;
                          break;
                }
                return t; 
           }
