    using System.Data.Linq;
    ....
    
    public static Image ConvertToImage(Binary iBinary)
            {
                var arrayBinary = iBinary.ToArray();
                Image rImage = null;
    
                using (MemoryStream ms = new MemoryStream(arrayBinary))
                {
                    rImage = Image.FromStream(ms);
                }
                return rImage;
            }
