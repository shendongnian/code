        /// <summary>
        /// Converts an Image to Byte array
        /// </summary>
        /// <param name="imageIn">Image to convert</param>
        /// <returns>byte array</returns>
        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        /// <summary>
        /// Converts an Byte array to and Image
        /// </summary>
        /// <param name="byteArrayIn">byre array</param>
        /// <returns>Image</returns>
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
