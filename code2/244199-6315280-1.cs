      public static Bitmap ConvertBinaryDataToImage(byte[] buffer)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
                Bitmap bmap = new Bitmap(ms);
                return bmap;
            }
