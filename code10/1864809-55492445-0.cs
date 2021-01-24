    ///////////////// add black as transparency /////////////////
            Bitmap bmpUImage = new Bitmap(plotBox_Method.Image);
            Mat output = new Mat();
            Mat Shading_Image = new Image<Bgr, byte>(bmpUImage).Mat;
            
            // puting a black rectangle for transparent area later
            Shading_Image.CopyTo(output);
            CvInvoke.Rectangle(output, mask_rect, new MCvScalar(0,0,0), -1);
            
            Mat imageMat = output;
            Mat finalMat = new Mat(imageMat.Rows, imageMat.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 4);
            Mat tmp = new Mat(imageMat.Rows, imageMat.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            Mat alpha = new Mat(imageMat.Rows, imageMat.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            CvInvoke.CvtColor(imageMat, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(tmp, alpha, 0, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            CvInvoke.Imshow("alpha", alpha);
            VectorOfMat rgb = new VectorOfMat(3);
            CvInvoke.Split(imageMat, rgb);
            Mat[] rgba = { rgb[0], rgb[1], rgb[2], alpha };
            VectorOfMat vector = new VectorOfMat(rgba);
            CvInvoke.Merge(vector, finalMat);
            imgPlot.Image = finalMat.ToImage<Bgra, Byte>().ToBitmap(); 
            ///////////////// end of add black as transparency /////////////////
