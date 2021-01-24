lang_cs
        static void Main(string[] args)
        {
            //string image = "";
            //byte[] imageAsByteStream = Encoding.ASCII.GetBytes(image);
            byte[] imageAsByteStream = File.ReadAllBytes("../../../MARBIBM.TIF");
            //int imageByteStreamLength = imageAsByteStream.Length;
            //string base64EncodedImage = Convert.ToBase64String(imageAsByteStream);
            //imageAsByteStream = Encoding.ASCII.GetBytes(base64EncodedImage);
            Stream imageStream = TiffImageSplitter.ByteArrayToMemoryStream(imageAsByteStream);
            // Image splitImage = TiffImageSplitter.getTiffImage(imageStream, 1);
            TiffImageSplitter.tiff2PDF(imageStream);
        }
2) method `tiff2PDF` should be like that
lang_cs
        public static void tiff2PDF(Stream imageByteStream)
        {
            PdfDocument doc = new PdfDocument();
            int pageCount = getPageCount(imageByteStream);
            for (int i = 0; i < pageCount; i++)
            {
                PdfPage page = new PdfPage();
                Image img = getTiffImage(imageByteStream, i); //<---HERE WAS ANOTHER ERROR, LOOK AT i
                XImage imgFrame = XImage.FromGdiPlusImage(img);
3)
lang_cs
        public static MemoryStream ByteArrayToMemoryStream(byte[] bytestream)
        {
            MemoryStream stream = new MemoryStream(bytestream);
            //stream.Write(bytestream, 0, bytestream.Length); 
            return stream;
        }
  [1]: http://www.fileformat.info/format/tiff/sample/
