        public static Emgu.CV.Mat EnterAtCenter(int Size = 100)
        {
            /*Create Mat and Image large, white*/
            Emgu.CV.Mat Large = Emgu.CV.Mat.Zeros(Size, Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            Emgu.CV.CvInvoke.BitwiseNot(Large, Large);
            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> ImageLarge = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(Large.Bitmap);
            /*Create Mat and Image small, black*/
            Emgu.CV.Mat Small = Emgu.CV.Mat.Zeros(10, 10, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> ImageSmall = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(Small.Bitmap);
            /*Copy small Image to large Image at 5,5*/
            ImageLarge.ROI = new System.Drawing.Rectangle(5, 5, Small.Width, Small.Height);
            ImageSmall.CopyTo(ImageLarge);
            ImageLarge.ROI = System.Drawing.Rectangle.Empty;
            return ImageLarge.Mat;
        }
