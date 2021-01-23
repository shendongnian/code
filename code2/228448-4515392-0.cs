    public class ImageProvider {
        private readonly ProductProvider ProductProvider = null;
        private readonly EncoderParameters DefaultQualityEncoder = new EncoderParameters();
        private readonly EncoderParameters HighQualityEncoder = new EncoderParameters();
        private readonly ImageCodecInfo JpegCodecInfo = ImageCodecInfo.GetImageEncoders().Single(
            c =>
                (c.MimeType == "image/jpeg"));
        private readonly Size[] Sizes = new Size[3] {
            new Size(640, 0),
            new Size(280, 0),
            new Size(80, 0)
        };
        private readonly string Path = HttpContext.Current.Server.MapPath("~/Resources/Images/Products");
        public ImageProvider(
            ProductProvider ProductProvider) {
            this.ProductProvider = ProductProvider;
            this.DefaultQualityEncoder.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
            this.HighQualityEncoder.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
        }
        private void Crop(
            string FileName,
            Image Image,
            Crop Crop) {
            using (Bitmap Source = new Bitmap(Image)) {
                Source.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);
                using (Bitmap Target = new Bitmap(Crop.Width, Crop.Height, Image.PixelFormat)) {
                    Target.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);
                    using (Graphics Graphics = Graphics.FromImage(Target)) {
                        Graphics.CompositingMode = CompositingMode.SourceCopy;
                        Graphics.CompositingQuality = CompositingQuality.HighQuality;
                        Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphics.PageUnit = GraphicsUnit.Pixel;
                        Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphics.SmoothingMode = SmoothingMode.HighQuality;
                        Graphics.DrawImage(Source, new Rectangle(0, 0, Target.Width, Target.Height), new Rectangle(Crop.Left, Crop.Top, Crop.Width, Crop.Height), GraphicsUnit.Pixel);
                    };
                    Target.Save(FileName, JpegCodecInfo, HighQualityEncoder);
                };
            };
        }
        public void CropAndResize(
            Product Product,
            Crop Crop) {
            using (Image Temp = Image.FromFile(String.Format("{0}/{1}.temp", Path, Product.ProductId))) {
                Img Img = new Img();
                this.ProductProvider.AddImageAndSave(Product, Img);
                this.Crop(String.Format("{0}/{1}.cropped", Path, Img.ImageId), Temp, Crop);
                using (Image Cropped = Image.FromFile(String.Format("{0}/{1}.cropped", Path, Img.ImageId))) {
                    this.Resize(String.Format("{0}/{1}-L.jpg", Path, Img.ImageId), this.Sizes[0], Cropped, DefaultQualityEncoder);
                    this.Resize(String.Format("{0}/{1}-T.jpg", Path, Img.ImageId), this.Sizes[1], Cropped, DefaultQualityEncoder);
                    this.Resize(String.Format("{0}/{1}-S.jpg", Path, Img.ImageId), this.Sizes[2], Cropped, DefaultQualityEncoder);
                };
            };
            this.Purge(Product);
        }
        public void QueueFor(
            Product Product,
            Size Size,
            HttpPostedFileBase PostedFile) {
            using (Image Image = Image.FromStream(PostedFile.InputStream)) {
                this.Resize(String.Format("{0}/{1}.temp", Path, Product.ProductId), Size, Image, HighQualityEncoder);
            };
        }
        private void Purge(
            Product Product) {
            string Temp = String.Format("{0}/{1}.temp", Path, Product.ProductId);
            if (File.Exists(Temp)) {
                File.Delete(Temp);
            };
            foreach (Img Img in Product.Imgs) {
                string Cropped = String.Format("{0}/{1}.cropped", Path, Img.ImageId);
                if (File.Exists(Cropped)) {
                    File.Delete(Cropped);
                };
            };
        }
        private void Resize(
            string FileName,
            Size Size,
            Image Image,
            EncoderParameters EncoderParameters) {
            if (Size.Height == 0) {
                Size.Height = (int)(Image.Height / ((float)Image.Width / (float)Size.Width));
            };
            using (Bitmap Bitmap = new Bitmap(Image, Size)) {
                Bitmap.Save(FileName, JpegCodecInfo, EncoderParameters);
            };
        }
    }
