    private Image<Gray,byte> FillHoles(Image<Gray,byte> image)
        {
            var resultImage = image.CopyBlank();
            Gray gray = new Gray(255);
            using (var mem = new MemStorage())
            {
                for (var contour = image.FindContours(
                    CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, 
                    RETR_TYPE.CV_RETR_CCOMP, 
                    mem); contour!= null; contour = contour.HNext)
                {
                    resultImage.Draw(contour, gray, -1);
                }
            }
            return resultImage;
        }
