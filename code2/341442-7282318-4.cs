    public class ImageUtility
    {
        private Image image1;
        private Image image2;
        
        public ImageUtility(Image image1, Image image2)
        {
            this.image1 = image1;
            this.image2 = image2;
        }
        public void SaveTransitions(int numSteps, string outDir)
        {
            var opacityChange = 1.0f/(float) numSteps;
            for(float opacity = 1,i=0;opacity>0;opacity-=opacityChange,i++)
            {
                using(var image = new Bitmap(image1.Width,image2.Width))
                {
                    Graphics g = Graphics.FromImage(image);
                    ColorMatrix matrix1 = new ColorMatrix();
                    matrix1.Matrix33 = opacity;
                    ImageAttributes attributes1 = new ImageAttributes();
                    attributes1.SetColorMatrix(matrix1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    ColorMatrix matrix2 = new ColorMatrix();
                    matrix2.Matrix33 = 1 - opacity;
                    ImageAttributes attributes2 = new ImageAttributes();
                    attributes2.SetColorMatrix(matrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(image1, new Rectangle(0, 0, image1.Width, image1.Height), 0, 0, image1.Width,
                                         image1.Height, GraphicsUnit.Pixel, attributes1);
                    g.DrawImage(image2, new Rectangle(0, 0, image2.Width, image2.Height), 0, 0, image2.Width,
                                         image2.Height, GraphicsUnit.Pixel, attributes2);
                    image.Save(Path.Combine(outDir,"Image" + i + ".png"),ImageFormat.Png);
                }
            }
        }
